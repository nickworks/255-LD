using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takens
{
    public class PlayerMovement : MonoBehaviour
    {


        private enum Movement { leftTurn, rightTurn, walking, none };
        private Movement currentMotion;
        private int currentRoom = 0;

        private float startingXPos;

        private float ticker;
        private Quaternion initialRotation;
        private Vector3 initialPosition;

        [SerializeField]
        private float rotationSpeed = .1f;
        [SerializeField]
        private float movementSpeed = .1f;
        [SerializeField]
        private AnimationCurve SCurve;
        [SerializeField]
        private GameObject rotationObject;
        [SerializeField]
        private GameObject pitchControl;
        [SerializeField]
        private GameObject yawControl;
        [SerializeField]
        private float sensitivityX = 5f;
        [SerializeField]
        private float sensitivityY = 5f;
        private float maxY = 20f;
        private float maxX = 20f;

        private float pitch = 0f;
        private float yaw = 0f;

        // Start is called before the first frame update
        void Start()
        {
            currentMotion = Movement.none;
        }

        // Update is called once per frame
        void Update()
        {
            
            if (currentMotion == Movement.none)
            {
                float h = sensitivityX * Input.GetAxis("Mouse X");
                float v = sensitivityY * Input.GetAxis("Mouse Y");

                pitch += v;
                yaw += h;

                if (pitch > maxY) pitch = maxY;
                else if (pitch < -maxY) pitch = -maxY;
                if (yaw > maxX) yaw = maxX;
                else if (yaw < -maxX) yaw = -maxX;

                pitchControl.transform.localEulerAngles = new Vector3(-pitch, 0, 0);
                yawControl.transform.localEulerAngles = new Vector3(0, yaw, 0);


                // pitch.transform.Rotate(0, h, 0);
                //cam.transform.Rotate(-v, h, 0);

                if (Input.GetKeyDown(KeyCode.A))
                {
                    initialRotation = transform.rotation;
                    rotationObject.transform.Rotate(0, -90, 0);
                    ticker = 0;
                    currentMotion = Movement.leftTurn;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    walk();
                    //walk
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    initialRotation = transform.rotation;
                    rotationObject.transform.Rotate(0, 90, 0);
                    ticker = 0;
                    currentMotion = Movement.rightTurn;

                }
            }
            else
            {
                switch (currentMotion)
                {
                    case Movement.leftTurn:
                        ticker += rotationSpeed * Time.deltaTime;
                        if (ticker > 1)
                            ticker = 1;
                        transform.rotation = Quaternion.Lerp(initialRotation, rotationObject.transform.rotation, SCurve.Evaluate(ticker));
                        if (ticker == 1)
                        {
                            currentMotion = Movement.none;
                            ticker = 0;
                        }
                        break;
                    case Movement.rightTurn:
                        ticker += rotationSpeed * Time.deltaTime;
                        if (ticker > 1)
                            ticker = 1;
                        transform.rotation = Quaternion.Lerp(initialRotation, rotationObject.transform.rotation, SCurve.Evaluate(ticker));
                        if (ticker == 1)
                        {
                            currentMotion = Movement.none;
                            ticker = 0;
                        }
                        break;
                    case Movement.walking:
                        ticker += movementSpeed * Time.deltaTime;
                        if (ticker > 1)
                            ticker = 1;
                        transform.position = Vector3.Lerp(initialPosition, rotationObject.transform.position, SCurve.Evaluate(ticker));
                        if (ticker == 1)
                        {
                            currentMotion = Movement.none;
                            ticker = 0;
                        }
                        break;
                    default:
                        Debug.Log("Unrecognized form of motion!");
                        break;
                }
            }



        }

        private bool walk()
        {
            int rot = (int)Mathf.Round(transform.localEulerAngles.y);
            if (currentRoom == 0)
            {
                switch (rot)
                {
                    case (0):
                        break;
                    case (90):
                        break;
                    case (180):
                        break;
                    case (270):
                        if (Inventory.main.hasUnlockedDoorOne)
                        {
                            rotationObject.transform.position = new Vector3(-14f, 1.3f, .76f);
                            initialPosition = transform.position;
                            currentMotion = Movement.walking;
                            ticker = 0;
                            currentRoom = 1;

                        }
                        break;
                    default:
                        break;
                }
            }
            else if (currentRoom == 1)
            {
                switch (rot)
                {
                    case (0):
                        break;
                    case (90):
                        rotationObject.transform.position = new Vector3(-2f, 1.3f, .76f);
                        initialPosition = transform.position;
                        currentMotion = Movement.walking;
                        ticker = 0;
                        currentRoom = 0;
                        break;
                    case (180):
                        break;
                    case (270):
                        if (Inventory.main.hasUnlockedDoorTwo)
                        {
                            rotationObject.transform.position = new Vector3(-28f, 1.3f, .76f);
                            initialPosition = transform.position;
                            currentMotion = Movement.walking;
                            ticker = 0;
                            currentRoom = 2;

                        }
                        break;
                    default:
                        break;
                }
            }
            else if (currentRoom == 2)
            {

                switch (rot)
                {
                    case (0):
                        break;
                    case (90):
                        rotationObject.transform.position = new Vector3(-14f, 1.3f, .76f);
                        initialPosition = transform.position;
                        currentMotion = Movement.walking;
                        ticker = 0;
                        currentRoom = 1;
                        break;
                    case (180):
                        break;
                    case (270):
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
    }
}