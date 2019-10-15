using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class PickupKey2 : MonoBehaviour {

        void OnMouseDown()
        {
            Inventory.main.hasKey2 = true;
            Destroy(gameObject);
        }
    }
}
