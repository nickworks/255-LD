using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powers
{
    public class ObjectRotation : MonoBehaviour
    {
        public float rotationSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
        }
    }
}