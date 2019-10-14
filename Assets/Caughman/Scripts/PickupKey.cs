using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caughman
{
    public class PickupKey : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Inventory.main.hasKey = true;
            Destroy(gameObject);
        }
    }
}