using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerTrigger : MonoBehaviour
{
    float power;
    public float maxPower = 100f;
    PlungerButton plungerButton;
    public GameObject plunger;
    public GameObject plungerGuard;
    public GameObject player;
    List<Rigidbody> ballList = new List<Rigidbody>();

    void Start()
    {
        plungerButton = plunger.GetComponent<PlungerButton>();
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
            plungerGuard.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
        player.SetActive(false);
        plungerGuard.SetActive(true);
        power = 0f;
    }
}
