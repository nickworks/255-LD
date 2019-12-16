using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class InteractScriptRoomOnePhoto : MonoBehaviour
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

        public GameObject photo;
        public Animation keyHider;

        private bool inTrigger = false;

        private void OnMouseOver()
        {
            //checks to see if the player must be in a trigger and, if so, if they are in the trigger
            if (inTrigger && inventory.haveRoomOnePhoto == true && inventory.currentlySelectedItem == 2 || inTrigger && inventory.haveRoomTwoPhoto == true && inventory.currentlySelectedItem == 5 || inTrigger && inventory.haveRoomThreePhoto == true && inventory.currentlySelectedItem == 8)
            {
                //if interaction available, highlight.
                affectedMaterial.SetColor("_EmissionColor", hoverColor);

                //if mouse down and an interaction available, do an interaction.
                if (Input.GetButtonDown("Submit"))
                {
                    photo.SetActive(true);
                    keyHider.Play("room1_openKeyHolder");
                    inventory.currentlySelectedItem = 0;
                    inventory.haveRoomOnePhoto = false;
                    inventory.haveRoomTwoPhoto = false;
                    inventory.haveRoomThreePhoto = false;
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