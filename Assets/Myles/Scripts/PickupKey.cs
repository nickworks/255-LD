using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class PickupKey : MonoBehaviour
    {
        void OnMouseDown()
        {
            Inventory.main.hasKey = true;
            Destroy(gameObject);
        }
    }
}
