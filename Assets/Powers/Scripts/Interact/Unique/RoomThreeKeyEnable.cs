﻿using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class RoomThreeKeyEnable : MonoBehaviour
    {
        public InventoryScript inventory;

        [Space(10)]

        [Header("Material Effect")]
        [Tooltip("The material affected.")]
        public Material affectedMaterial;
        [Tooltip("The default emission color.")]
        public Color defaultColor;
        [Tooltip("The emission color on mouse hover.")]
        public Color hoverColor;

        private bool inTrigger = false;

        private void OnMouseOver()
        {
            //checks to see if the player must be in a trigger and, if so, if they are in the trigger
            if (inTrigger)
            {
                affectedMaterial.SetColor("_EmissionColor", hoverColor);

                //if mouse down and an interaction available, do an interaction.
                if (Input.GetButtonDown("Submit"))
                {
                    inventory.haveRoomThreeKey = true;
                    affectedMaterial.SetColor("_EmissionColor", defaultColor);
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnMouseExit()
        {
            //change back to default color.
            affectedMaterial.SetColor("_EmissionColor", defaultColor);
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.tag == "Player") inTrigger = true;
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.tag == "Player") inTrigger = false;
        }
    }
}