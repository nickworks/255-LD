using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuLeverBase : MonoBehaviour
    {
        public GameObject Pole;
        public GameObject Handle;

        public GameObject ClockHand;
        bool isRotating = false;
        public float rotationValue = 5;

        public GameObject targetTop;
        public GameObject targetBottom;
        public GameObject targetClock;


        // Start is called before the first frame update
        void Start()
        {
            if ( BreuWorldControllerr.main.placedPole == false)
            {
                Pole.SetActive(false);
            }
            if ( BreuWorldControllerr.main.placedHandle == false)
            {
                Handle.SetActive(false);
            }
        }

        public void OnMouseUp()
        {
            if(BreuInventory.main.usingPole == true)
            {
                Pole.SetActive(true);
                BreuInventory.main.usingPole = false;
                BreuInventory.main.hasPole = false;
                BreuWorldControllerr.main.placedPole = true;
                
            }
            if (BreuInventory.main.usingHandle == true && BreuWorldControllerr.main.placedPole == true)
            {
                Handle.SetActive(true);
                BreuInventory.main.usingHandle = false;
                BreuInventory.main.hasHandle = false;
                BreuWorldControllerr.main.placedHandle = true;
                
            }
            if (BreuInventory.main.usingLever == true)
            {
                Pole.SetActive(true);
                Handle.SetActive(true);
                BreuInventory.main.usingLever = false;
                BreuInventory.main.hasLever = false;
                BreuWorldControllerr.main.placedHandle = true;
                BreuWorldControllerr.main.placedHandle = true;

            }
            if (BreuWorldControllerr.main.placedClock == true && BreuWorldControllerr.main.placedHandle == true)
            {
                if(isRotating == false && BreuWorldControllerr.main.completedClock == false)
                {
                    isRotating = true;
                }
                else
                {
                    isRotating = false;
                }
            }
        }

        public void Update()
        {
            if (isRotating == true)
            {
                ClockHand.transform.Rotate(new Vector3(0, 0, rotationValue) * Time.deltaTime);
            }
            if (isRotating == false)
            {
                float baseAngle = getAngleRad(targetBottom.transform.position.x, targetTop.transform.position.x, targetBottom.transform.position.y, targetTop.transform.position.y);
                float madeAngle = getAngleRad(targetBottom.transform.position.x, targetClock.transform.position.x, targetBottom.transform.position.y, targetClock.transform.position.y);
                
                if (madeAngle >= baseAngle && madeAngle < 0)
                {
                    BreuWorldControllerr.main.completedClock = true;
                }
            }
        }

        float getLength(float X1, float X2, float Y1, float Y2)
        {
            float x = X2 - X1;
            float y = Y2 - Y1;

            return Mathf.Sqrt((x * x) + (y * y));
        }

        float getAngleRad (float x1, float x2, float y1, float y2)
        {
            float x = x1 - x2;
            float y = y1 - y2;

            return Mathf.Atan2(y, x);
        }
    }
}