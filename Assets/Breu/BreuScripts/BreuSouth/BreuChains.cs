using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuChains : MonoBehaviour
    {
        public GameObject Chains;
        void Update()
        {
            if (BreuWorldControllerr.main.brokeChains == true)
            {
                Destroy(Chains);
            }
        }

        void OnMouseUp()
        {
            if (BreuInventory.main.usingCutter == true)
            {
                BreuWorldControllerr.main.brokeChains = true;
                BreuInventory.main.usingCutter = false;

            }
        }
    }
}