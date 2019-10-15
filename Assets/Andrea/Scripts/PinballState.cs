using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballState : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        player.SetActive(true);
    }
}
