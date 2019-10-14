using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class PickupKey : MonoBehaviour {

        void OnMouseDown()
        {
            Inventory.main.hasKey = true;
            Destroy(gameObject);
        }
    }
}
