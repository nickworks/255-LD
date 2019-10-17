using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class PickupKey1 : MonoBehaviour {

        void OnMouseDown()
        {
            Inventory.main.hasKey1 = true;
            Destroy(gameObject);
        }
    }
}
