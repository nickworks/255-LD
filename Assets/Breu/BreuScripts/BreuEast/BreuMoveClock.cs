using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuMoveClock : MonoBehaviour
    {
        public GameObject ClockHand;
        bool isRotating = false;
        Quaternion rotation = Quaternion.Euler(0, 0, 5);

        public void OnMouseUp()
        {
            
            if (BreuWorldControllerr.main.placedClock == true && isRotating == false)
            {
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
        }
        public void Update()
        {
            print("clicked");
            if (isRotating == true)
            {
                ClockHand.transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime);
            }
        }
    }
}