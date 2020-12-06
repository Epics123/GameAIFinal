using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    [SerializeField]
    private Transform[] coverTransforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform[] GetCoverTransforms()
    {
        return coverTransforms;
    }
}
