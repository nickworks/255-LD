using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballState : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    private Vector3 ballStartingPos = new Vector3();
    void Start()
    {
        ballStartingPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        Instantiate(ball, ballStartingPos, Quaternion.identity);        
    }
}
