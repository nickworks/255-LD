using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class Rotator : MonoBehaviour {
        Vector3 startPosition;

        public bool useSin = false;
        public bool useCos = false;

        void Start()
        {
            startPosition = transform.position;
        }


        void Update()
        {
            float x = startPosition.x;
            float y = startPosition.y;
            float z = startPosition.z;

            if (useSin)
                y = y + 20 * Mathf.Sin(Time.timeSinceLevelLoad);
            if (useCos)
                x = x + 20 * Mathf.Cos(Time.timeSinceLevelLoad);

            transform.position = new Vector3(x, y, z);
        }
    }
}
