using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public List<Node> reachableNodes = new List<Node>();


    [HideInInspector]
    public Collider col;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

}
