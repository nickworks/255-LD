using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Takens
{
    public class ItemController : MonoBehaviour
    {
        public ItemType thisItem;
        private InvGUI i;
        public void Start()
        {
            i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>();
        }
        void OnMouseDown()
        {
            switch (thisItem)
            {
                case (ItemType.keyOne):
                    i.displayMessage("You picked up an old door key!");
                    break;
                case (ItemType.keyTwo):
                    i.displayMessage("You picked up an old door key!");
                    break;
                default:
                    break;
            }

            Inventory.main.Set(thisItem, true);
            Destroy(gameObject);
        }
    }
}
