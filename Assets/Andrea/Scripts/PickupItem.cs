using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class PickupItem : Interactable
    {
        public Item item;

        public override void Interact()
        {
            if (item != Item.None)
            {
                Inventory.singleton.Set(item);
                Destroy(gameObject);
            }
            Debug.Log("Interacted with Item");
        }

    }
}