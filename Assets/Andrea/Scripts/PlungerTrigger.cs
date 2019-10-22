using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{
    public class PlungerTrigger : Interactable
    {
        float power;
        public float maxPower = 100f;
        PlungerButton plungerButton;
        public GameObject plunger;
        public GameObject player;
        public GameObject ball;
        public GameObject scorePanel;
        //private Vector3 ballStartingPos = new Vector3();
        List<Rigidbody> ballList = new List<Rigidbody>();
        public PinballScore pinballScore;

        private Text scoreText;

        void Start()
        {
            plungerButton = plunger.GetComponent<PlungerButton>();
            
            //ballStartingPos = ball.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (ballList.Count != 0)
            {
                if (plungerButton.isPressed)
                {
                    power += 50 * Time.deltaTime;

                    if (power > maxPower)
                    {
                        power = maxPower;
                    }
                }
                else
                {
                    foreach (Rigidbody r in ballList)
                    {
                        r.AddForce(power * Vector3.forward);
                    }
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                ballList.Add(other.gameObject.GetComponent<Rigidbody>());
                scorePanel.SetActive(false);
                //plungerGuard.SetActive(false);
            }
        }

        void OnTriggerExit(Collider other)
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            //player.SetActive(false);
            //plungerGuard.SetActive(true);
            power = 0f;
            pinballScore.Reset();
            scorePanel.SetActive(true);
        }
    }
}