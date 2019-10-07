using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuKey : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (BreuInventory.main.foundKey == true)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDown()
        {
            BreuInventory.main.foundKey = true;
            Destroy(gameObject);
        }
    }
}