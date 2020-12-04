using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCoverNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI enemyAI;

    public MoveToCoverNode(NavMeshAgent agent, EnemyAI ai)
    {
        this.agent = agent;
        enemyAI = ai;
    }

    public override NodeState Evaluate()
    {
        Transform cover = enemyAI.GetBestCover();
        if (cover == null)
            return NodeState.FAILURE;

        enemyAI.SetColor(Color.red);
        float distance = Vector3.Distance(cover.position, agent.transform.position);
        if(distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(cover.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
