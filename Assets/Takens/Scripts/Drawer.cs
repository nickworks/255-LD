using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens
{
    public class Drawer : MonoBehaviour
    {
        public bool isOpen = false;
        public bool isLocked = false;
        private bool isMoving = false;
        private float distance = 6f;
        private float speed = .05f;
        private Vector3 InitialPos;
        private InvGUI invgui;
        public bool failMessage = false;
        public ItemType itemToUnlock = ItemType.empty;

        void Start()
        {
            InitialPos = transform.localPosition;
            invgui = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>();
            if (isOpen)
            {
                transform.localPosition = new Vector3(InitialPos.x, InitialPos.y + distance, InitialPos.z);
            }
        }
        // Update is called once per frame
        void OnMouseDown()
        {
            if (!isLocked && !isMoving)
            {
                if (isOpen)
                {
                    StartCoroutine("CloseDrawer");
                }
                else
                {

                    StartCoroutine("OpenDrawer");
                }

            }
            else if (isLocked)
            {
                if (Inventory.main.selectedItem != ItemType.empty)
                {
                    if (Inventory.main.selectedItem == ItemType.nightStandKey && itemToUnlock == ItemType.nightStandKey)
                    {
                        isLocked = false;
                        invgui.displayMessage("You unlocked the nightstand!");
                        Inventory.main.Set(ItemType.nightStandKey, false);
                    }
                    else if (itemToUnlock == ItemType.candleStick && Inventory.main.hasCompletedCandleStick)
                    {
                        isLocked = false;
                        StartCoroutine("OpenDrawer");
                    }
                    else if (failMessage)
                    {
                        if(Inventory.main.selectedItem == ItemType.keyOne || Inventory.main.selectedItem == ItemType.keyTwo)
                        {
                            invgui.displayMessage("This key doesn't fit!");
                        }
                        else if(Inventory.main.selectedItem == ItemType.nightStandKey)
                        {
                            invgui.displayMessage("This drawer seems to be locked by a different mechanism!");
                        }
                        else
                        {
                            invgui.displayMessage("You can't use that here!");
                        }
                    }
                    
                }
                else if(itemToUnlock == ItemType.candleStick && Inventory.main.hasCompletedCandleStick)
                {
                    isLocked = false;
                    StartCoroutine("OpenDrawer");
                }
                else if (failMessage)
                {
                        invgui.displayMessage("This drawer is locked!");
                }
            }
        }


        public IEnumerator OpenDrawer()
        {
            isOpen = true;
            isMoving = true;

            while (transform.localPosition.y < (InitialPos.y + distance))
            {

                transform.Translate(0f, speed, 0f, Space.Self);
                yield return null;
            }
            //code

            isMoving = false;
        }

        public IEnumerator CloseDrawer()
        {
            isMoving = true;
            isOpen = false;
            while (transform.localPosition.y > InitialPos.y)
            {
                transform.Translate(0f, -speed, 0f, Space.Self);
                yield return null;
            }
            transform.localPosition = InitialPos;
            isMoving = false;
        }

    }
}