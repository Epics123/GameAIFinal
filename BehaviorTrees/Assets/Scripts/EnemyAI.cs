using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float startHealth;
    [SerializeField]
    private float lowHealthThreshold;
    [SerializeField]
    private float healRate;

    [SerializeField]
    private float chaseRange;
    [SerializeField]
    private float shootRange;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private List<Cover> availableCovers;

    private Material material;
    private Transform bestCoverLocation;
    private NavMeshAgent agent;

    private Node topNode;

    private float enemyCurrentHelth;

    public float currentHealth
    {
        get { return enemyCurrentHelth; }
        set { enemyCurrentHelth = Mathf.Clamp(value, 0, startHealth); }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHelth = startHealth;
        ConstructBehaviorTree();
    }

    // Update is called once per frame
    void Update()
    {
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.black);
            agent.isStopped = true;
        }
        currentHealth += Time.deltaTime * healRate;
    }

    private void ConstructBehaviorTree()
    {
        //Custom Nodes
        IsCoverAvailableNode coverAvailableNode = new IsCoverAvailableNode(availableCovers, playerTransform, this);
        MoveToCoverNode moveToCoverNode = new MoveToCoverNode(agent, this);
        HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        IsCoveredNode isCoveredNode = new IsCoveredNode(playerTransform, transform);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        RangeNode chaseRangeNode = new RangeNode(chaseRange, playerTransform, transform);
        RangeNode shootRangeNode = new RangeNode(shootRange, playerTransform, transform);
        ShootNode shootNode = new ShootNode(agent, this);

        //Sequence Nodes
        Sequence chaseSequence = new Sequence(new List<Node> { chaseRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootRangeNode, shootNode });
        Sequence moveToCoverSequence = new Sequence(new List<Node> { coverAvailableNode, moveToCoverNode });

        //Selector Nodes
        Selector findCoverSelector = new Selector(new List<Node> { moveToCoverSequence, chaseSequence });
        Selector takeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });

        Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, takeCoverSelector });

        topNode = new Selector(new List<Node> { mainCoverSequence, shootSequence, chaseSequence });
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetBestCoverLocation(Transform location)
    {
        bestCoverLocation = location;
    }

    public Transform GetBestCover()
    {
        return bestCoverLocation;
    }
}
