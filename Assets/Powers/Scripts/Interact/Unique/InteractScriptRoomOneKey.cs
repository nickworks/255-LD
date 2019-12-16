using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class InteractScriptRoomOneKey : MonoBehaviour
    {
        [Header("Material Effect")]
        [Tooltip("The material affected.")]
        public Material affectedMaterial;
        [Tooltip("The default emission color.")]
        public Color defaultColor;
        [Tooltip("The emission color on mouse hover.")]
        public Color hoverColor;

        [Space(10)]

        public InventoryScript inventory;

        public Animation key;
        public Animator door;

        private bool inTrigger = false;

        private void OnMouseOver()
        {
            //checks to see if the player must be in a trigger and, if so, if they are in the trigger
            if (inTrigger && inventory.haveRoomOneKey == true && inventory.currentlySelectedItem == 3 || inTrigger && inventory.haveRoomTwoKey == true && inventory.currentlySelectedItem == 6 || inTrigger && inventory.haveRoomThreeKey == true && inventory.currentlySelectedItem == 9)
            {
                //if interaction available, highlight.
                affectedMaterial.SetColor("_EmissionColor", hoverColor);

                //if mouse down and an interaction available, do an interaction.
                if (Input.GetButtonDown("Submit"))
                {
                    key.Play("room1_keyTurn");
                    door.Play("DoorOpen", 0, 0f);
                    inventory.haveRoomOneKey = false;
                    inventory.haveRoomTwoKey = false;
                    inventory.haveRoomThreeKey = false;
                    inventory.currentlySelectedItem = 0;
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