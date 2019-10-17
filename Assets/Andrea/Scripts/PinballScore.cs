using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballScore : MonoBehaviour
{
    public int score;
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        score = 0;
    }
}
