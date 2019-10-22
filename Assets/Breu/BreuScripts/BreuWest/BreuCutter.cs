using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuCutter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (BreuInventory.main.foundCutter == true)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnMouseUp()
        {
            if (BreuInventory.main.foundCutter == false)
            {
                BreuInventory.main.foundCutter = true;
                BreuInventory.main.hasCutter = true;
                Destroy(gameObject);
            }
        }
    }
}