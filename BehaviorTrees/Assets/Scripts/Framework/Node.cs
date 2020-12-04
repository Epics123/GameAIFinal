using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
    protected NodeState mNodeState;
    public NodeState nodeState { get { return mNodeState; } }

    public abstract NodeState Evaluate();
}

public enum NodeState
{
    RUNNING, SUCCESS, FAILURE
}
