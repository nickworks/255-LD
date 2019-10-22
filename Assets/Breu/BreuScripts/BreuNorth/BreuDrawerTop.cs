using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuDrawerTop : MonoBehaviour
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
            if (BreuInventory.main.foundHandle == false)
            {
                BreuInventory.main.foundHandle = true;
                BreuInventory.main.hasHandle = true;
            }
        }
    }
}