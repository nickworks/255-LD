using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takens
{

    

    public class DoorOpen : MonoBehaviour
    {


        public int doorNumber = 0;
        private InvGUI i;
        public void Start()
        {
            i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>();
        }


        void OnMouseDown()
        {
            if (doorNumber == 0)
            {
                if (Inventory.main.selectedItem == ItemType.keyOne)
                {
                    Inventory.main.hasUnlockedDoorOne = true;
                    Inventory.main.Set(ItemType.keyOne, false);
                    GetComponent<Animator>().SetBool("isOpened", true);


                    //no longer need these scripts, the door object can stay
                    GetComponent<BoxCollider>().enabled = false;
                    //this.enabled = false;
                }
                else if(Inventory.main.selectedItem != ItemType.empty)
                {
                    i.displayMessage("You cant use that here!");
                }
                else
                {
                    i.displayMessage("This door is locked!");
                }
            }
            else if(doorNumber == 1)
            {
                if (Inventory.main.selectedItem == ItemType.keyTwo)
                {
                    Inventory.main.hasUnlockedDoorTwo = true;
                    Inventory.main.Set(ItemType.keyTwo, false);
                    GetComponent<Animator>().SetBool("isOpened", true);


                    //no longer need these scripts, the door object can stay
                    GetComponent<BoxCollider>().enabled = false;
                    //this.enabled = false;
                }
                else if (Inventory.main.selectedItem != ItemType.empty)
                {
                    i.displayMessage("You cant use that here!");
                }
                else
                {
                    i.displayMessage("This door is locked!");
                }
            }
        }
    }

}