using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandLean : MonoBehaviour
{
    public float handLeanTransition = 0.05f;
    public float handLeanIntensity = 5f;
    private float handLean = 0f;

    void Update()
    {
        handLean = Mathf.Lerp(handLean, Input.GetAxis("Horizontal"), handLeanTransition);
        handLean *= handLeanIntensity;
        handLean = Mathf.Clamp(handLean, -handLeanIntensity, handLeanIntensity);

        this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, handLean);
    }
}
