using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuButton1 : MonoBehaviour
    {
        public GameObject Chains;
        void update()
        {
            if (BreuWorldControllerr.main.brokeChains == true)
            {
                Destroy(Chains);
            }
        }

        void OnMouseUp()
        {
            if (BreuInventory.main.usingMallet == true)
            {
                BreuWorldControllerr.main.brokeChains = true;
                BreuInventory.main.usingCutter = false;

            }
        }
    }
}