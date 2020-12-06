using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();
    private int currentNodeIndex;

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        if(currentNodeIndex < nodes.Count)
        {
            mNodeState = nodes[currentNodeIndex].Evaluate();
            if (mNodeState == NodeState.RUNNING)
                return NodeState.RUNNING;
            else if(mNodeState == NodeState.FAILURE)
            {
                currentNodeIndex = 0;
                return NodeState.FAILURE;
            }
            else
            {
                currentNodeIndex++;
                if (currentNodeIndex < nodes.Count)
                    return NodeState.RUNNING;
                else
                {
                    currentNodeIndex = 0;
                    return NodeState.SUCCESS;
                }
            }
        }

        return NodeState.SUCCESS;
    }
}
