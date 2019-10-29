using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuDrawerBottom : MonoBehaviour
    {
        public void OnMouseUp()
        {
            if (BreuWorldControllerr.main.completedClock == true & BreuInventory.main.foundKey == false)
            {
                BreuInventory.main.foundKey = true;
                BreuInventory.main.hasKey = true;
            }
        }
        
    }
}