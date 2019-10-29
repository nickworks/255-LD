using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takens
{
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
                        i.displayMessage("You picked up an old key!");
                        break;
                    case (ItemType.keyTwo):
                        i.displayMessage("You picked up an old key!");
                        break;
                    case (ItemType.tinderBox):
                        i.displayMessage("You picked up a tinderbox!");
                        break;
                    case (ItemType.codeBreaker):
                        i.displayMessage("You picked up a codebreaker!");
                        break;
                    default:
                        break;
                }

                Inventory.main.Set(thisItem, true);
                Destroy(gameObject);
            }
        }
    }
}