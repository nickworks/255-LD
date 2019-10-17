using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPointValue : MonoBehaviour
{
    public int bumperValue = 50;
    public GameObject scoreManager;
    PinballScore pinballScore;

    void Start()
    {
        pinballScore = scoreManager.GetComponent<PinballScore>();
    }
    void OnCollisionEnter()
    {
        pinballScore.score += bumperValue;
    }

}
