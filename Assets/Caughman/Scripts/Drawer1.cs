using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Caughman {
    public class Drawer1 : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if (Inventory.main.hasKey == true)
        {
                Inventory.main.hasDrawerKey = true;
                Debug.Log("Drawer Key Get");
            } 
        }
    }
}