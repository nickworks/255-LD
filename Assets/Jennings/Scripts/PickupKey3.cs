using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class PickupKey3 : MonoBehaviour {

        void OnMouseDown()
        {
            Inventory.main.hasKey3 = true;
            Destroy(gameObject);
        }
    }
}
