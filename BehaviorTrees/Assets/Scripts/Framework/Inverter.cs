using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    protected Node node; //Node to be inverted

    public Inverter(Node node)
    {
        this.node = node;
    }

    public override NodeState Evaluate()
    {
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                mNodeState = NodeState.RUNNING;
                break;
            case NodeState.SUCCESS:
                mNodeState = NodeState.FAILURE;
                break;
            case NodeState.FAILURE:
                mNodeState = NodeState.SUCCESS;
                break;
            default:
                break;
        }

        return mNodeState;
    }
}
