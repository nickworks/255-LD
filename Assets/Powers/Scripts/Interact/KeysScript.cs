using UnityEngine;

namespace Powers
{
    public class KeysScript : MonoBehaviour
    {
        private KeypadScript parentKeypad;
        private BoxCollider collide;

        [Header("Material Effect")]
        [Tooltip("The material affected.")]
        public Material affectedMaterial;
        [Tooltip("The default emission color.")]
        public Color defaultColor;
        [Tooltip("The emission color on mouse hover.")]
        public Color hoverColor;

        [Tooltip("The number the keypad script will add.")]
        public string keypadNumber;

        private bool inTrigger;

        private void Start()
        {

            parentKeypad = GetComponentInParent<KeypadScript>();
            collide = GetComponent<BoxCollider>();

        }

        private void OnMouseOver()
        {
            affectedMaterial.SetColor("_EmissionColor", hoverColor);

            //if mouse down, add number
            if (Input.GetButtonDown("Submit"))
            {
                parentKeypad.currentPin = parentKeypad.currentPin + keypadNumber;
            }
        }

        private void OnMouseExit()
        {
            //change back to default color.
            affectedMaterial.SetColor("_EmissionColor", defaultColor);
        }

    }

}
