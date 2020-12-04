using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
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
                case NodeState.FAILURE:
                    mNodeState = NodeState.FAILURE;
                    return mNodeState;
            }
        }

        mNodeState = NodeState.SUCCESS;
        return mNodeState;
    }
}
