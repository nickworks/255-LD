using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuDrawerMiddle : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnMouseUp()
        {
            if (BreuInventory.main.foundClock == false)
            {
                BreuInventory.main.foundClock = true;
                BreuInventory.main.hasClock = true;
            }
        }
    }
}