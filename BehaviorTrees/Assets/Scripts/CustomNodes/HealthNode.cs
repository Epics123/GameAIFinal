using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private EnemyAI enemyAI;
    private float healthThreshold;

    public HealthNode(EnemyAI ai, float threshold)
    {
        enemyAI = ai;
        healthThreshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return enemyAI.currentHealth <= healthThreshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
