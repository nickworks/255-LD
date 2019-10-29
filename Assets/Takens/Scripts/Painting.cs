using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens
{
    public class Painting : MonoBehaviour
    {
        private InvGUI i;
        public bool isSmashed = false;
        public bool hasKey = true;
        public void Start()
        {
            i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>();
        }

        // Update is called once per frame
        void OnMouseDown()
        {
            if (hasKey)
            {
                if (isSmashed)
                {
                    
                    i.displayMessage("You picked up a nightstand key!");
                    Inventory.main.Set(ItemType.nightStandKey, true);
                    hasKey = false;
                }
                else if (Inventory.main.selectedItem == ItemType.hammer)
                {
                    isSmashed = true;
                    i.displayMessage("You smashed the glass!");
                }
                else if(Inventory.main.selectedItem != ItemType.empty)
                {
                    i.displayMessage("You cant use that here!");
                }
                else
                {
                    i.displayMessage("Something rattles behind the glass...");
                }
            }
        }
    }
}