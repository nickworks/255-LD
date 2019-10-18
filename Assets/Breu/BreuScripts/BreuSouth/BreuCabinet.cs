using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuCabinet : MonoBehaviour
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
            if (BreuInventory.main.foundPole == false)
            {
                BreuInventory.main.foundPole = true;
                BreuInventory.main.hasPole = true;
            }
        }
    }
}