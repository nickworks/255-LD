using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class HubDoorScript : MonoBehaviour
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

        [Tooltip("The scene to load.")]
        public string sceneName;

        [Space(10)]

        [Tooltip("The events to occur upon first click.")]
        public UnityEvent onClick;

        private bool inTrigger = false;

        private void OnMouseOver()
        {
            //checks to see if the player must be in a trigger and, if so, if they are in the trigger
            if (inTrigger && mustBeInTrigger || !mustBeInTrigger)
            {
                //if interaction available, highlight.
                if (inTrigger) affectedMaterial.SetColor("_EmissionColor", hoverColor);

                //if mouse down and an interaction available, do an interaction.
                if (Input.GetButtonDown("Submit")) onClick.Invoke();
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