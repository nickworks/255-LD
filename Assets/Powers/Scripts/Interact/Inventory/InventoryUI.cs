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

        // Update is called once per frame
        void Update()
        {
            //check button down
            if (Input.GetButtonDown("Fire2") && inventoryEnabled) inventoryEnabled = false;
            else if (Input.GetButtonDown("Fire2") && !inventoryEnabled) inventoryEnabled = true;

            //when inventory is enabled, unlock mouse and lock player. inverse when disabled.
            if (inventoryEnabled)
            {
                lookScript.enabled = false;
                moveScript.enabled = false;
                animator.speed = 0;
                Cursor.lockState = CursorLockMode.None;

            }
            else if (!inventoryEnabled)
            {
                lookScript.enabled = true;
                moveScript.enabled = true;
                lookScript.cursorLock = true;
            }
        }
    }
}

