using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class InventoryUI : MonoBehaviour
    {
        public InventoryScript inventory;

        public PlayerMovement moveScript;
        public PlayerLook lookScript;
        public Animator animator;

        private bool inventoryEnabled = false;
        private bool inventoryEnabledPrev = false;

        [HideInInspector]
        public bool inInventory = false;

        // Update is called once per frame
        void Update()
        {
            //check button down
            if (Input.GetButtonDown("Fire2") && inventoryEnabled) inventoryEnabled = false;
            else if (Input.GetButtonDown("Fire2") && !inventoryEnabled) inventoryEnabled = true;

            //when inventory is enabled, unlock mouse and lock player. inverse when disabled.
            if (inventoryEnabled && !inventoryEnabledPrev)
            {
                lookScript.enabled = false;
                moveScript.enabled = false;
                animator.speed = 0;
                Cursor.lockState = CursorLockMode.None;
                inInventory = true;
                inventory.currentlySelectedItem = 0;
            }
            else if (!inventoryEnabled && inventoryEnabledPrev || inventory.currentlySelectedItem != 0)
            {
                lookScript.enabled = true;
                moveScript.enabled = true;
                animator.speed = 1;
                lookScript.cursorLock = true;
                inInventory = false;
                if(inventory.currentlySelectedItem != 0) inventoryEnabled = false;
            }

            inventoryEnabledPrev = inventoryEnabled;
        }
    }
}

