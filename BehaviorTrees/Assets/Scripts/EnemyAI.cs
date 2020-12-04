using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float playerTransform;
    [SerializeField]
    private List<Cover> availableCovers;

    private Material material;
    private Transform bestCoverLocation;

    private float currentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, startHealth); }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth += Time.deltaTime * healRate;
    }

    public float GetHealth()
    {
        return currentHealth;
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
