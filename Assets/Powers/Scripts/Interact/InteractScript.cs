using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class InteractScript : MonoBehaviour
    {
        [Header("Material Effect")]
        [Tooltip("The material affected.")]
        public Material affectedMaterial;
        [Tooltip("The default emission color.")]
        public Color defaultColor;
        [Tooltip("The emission color on mouse hover.")]
        public Color hoverColor;

        [Tooltip("If enabled, the object will wait for the player to be in trigger.")]
        public bool mustBeInTrigger = false;

        [Space(10)]

        public InventoryScript inventory;
        public int selectedItemNeeded = 0;

        [Space(10)]

        [Tooltip("The events to occur upon first click.")]
        public UnityEvent onClick;
        [Tooltip("Decides if there is an additional interaction after the first click.")]
        public bool interactionAfterFirstClick;
        [Tooltip("If there is an additional interaction, it would go here.")]
        public UnityEvent afterClick;
        private bool alreadyClicked; //This is used to detect if an interaction has already occurred.

        private bool inTrigger = false;

        private void OnMouseOver()
        {
            //checks to see if the player must be in a trigger and, if so, if they are in the trigger
            if (inTrigger && mustBeInTrigger || !mustBeInTrigger)
            {
                //if interaction available, highlight.
                if (!interactionAfterFirstClick && !alreadyClicked || interactionAfterFirstClick && !alreadyClicked || interactionAfterFirstClick && alreadyClicked) affectedMaterial.SetColor("_EmissionColor", hoverColor);
                else affectedMaterial.SetColor("_EmissionColor", defaultColor);

                //if mouse down and an interaction available, do an interaction.
                if (Input.GetButtonDown("Submit") && !alreadyClicked && inventory.currentlySelectedItem == selectedItemNeeded)
                {
                    onClick.Invoke();
                    alreadyClicked = true;
                }
                else if (Input.GetButtonDown("Submit") && alreadyClicked && interactionAfterFirstClick && inventory.currentlySelectedItem == selectedItemNeeded) afterClick.Invoke();
                else if (Input.GetButtonDown("Submit") && inventory.currentlySelectedItem != selectedItemNeeded) inventory.cantUseObjectNotify.SetActive(true);
            }
            else affectedMaterial.SetColor("_EmissionColor", defaultColor);
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