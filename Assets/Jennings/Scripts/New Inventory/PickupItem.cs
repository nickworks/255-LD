using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {
    public class PickupItem : MonoBehaviour {

        public Item item;

        private void OnMouseDown()
        {
            Inventory.main.Set(item);
            Destroy(gameObject);
        }
    }
}
