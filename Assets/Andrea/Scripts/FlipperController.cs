using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public GameObject triggerButton;
    public float flipperPosition = 0f;

    HingeJoint hinge;
    JointSpring spring;


    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        spring = GetComponent<JointSpring>();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

    }

    void Update()
    {
        spring.targetPosition = flipperPosition;
        spring.spring = hitStrength;
        spring.damper = flipperDamper;
        hinge.spring = spring;
        hinge.useLimits = true;
    }

    void OnMouseDown()
    {
        //spring.targetPosition = pressedPosition;
    }

    void OnMouseUp()
    {
        //.targetPosition = restPosition;
    }

}
