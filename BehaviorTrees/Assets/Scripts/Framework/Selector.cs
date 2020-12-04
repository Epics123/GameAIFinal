using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach(var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    mNodeState = NodeState.RUNNING;
                    return mNodeState;
                case NodeState.SUCCESS:
                    mNodeState = NodeState.SUCCESS;
                    return mNodeState;
                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }
        }

        mNodeState = NodeState.FAILURE;
        return mNodeState;
    }
}
