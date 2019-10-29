using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerButton : MonoBehaviour
{
    public bool isPressed = false;

    void OnMouseDown()
    {
        isPressed = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
    }
}
