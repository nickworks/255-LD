using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Takens
{
    public class ItemController : MonoBehaviour
    {
        public ItemType thisItem;
        void OnMouseDown()
        {
            Inventory.main.Set(thisItem, true);
            Destroy(gameObject);
        }
    }
}
