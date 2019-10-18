using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuMallet : MonoBehaviour
    {
        public GameObject Mallet;
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
            if (BreuInventory.main.foundMallet == false)
            {
                BreuInventory.main.foundMallet = true;
                BreuInventory.main.hasMallet = true;
                Destroy(Mallet);
            }
        }

    }
}