using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class KeypadScript : MonoBehaviour
    {

        public Material indicator1;
        public Material indicator2;
        public Material indicator3;
        public Material indicator4;

        [Space(10)]

        public string correctPin = "";
        [HideInInspector]
        public string currentPin = "";

        public UnityEvent correctPinEvents;
        public InventoryScript inventory;

        // Update is called once per frame
        void Update()
        {
            if(currentPin.Length == correctPin.Length)
            {
                if(currentPin == correctPin)
                {
                    //set indicators to show correct and use unity event
                    SetColors(true, true, true, true);

                    correctPinEvents.Invoke();
                    inventory.haveRoomOneCode = false;
                    inventory.haveRoomTwoCode = false;
                    enabled = false;
                }
                else
                {
                    //set indicators to show incorrect
                    SetColors(false, false, false, false);
                    currentPin = "";
                }
            }
            else
            {
                if(currentPin.Length == 0) SetColors(false, false, false, false);
                else if (currentPin.Length == 1) SetColors(true, false, false, false);
                else if (currentPin.Length == 2) SetColors(true, true, false, false);
                else if (currentPin.Length == 3) SetColors(true, true, true, false);
            }
        }

        //used to set colors, true means green, false means red
        void SetColors(bool indicOneTrue, bool indicTwoTrue, bool indicThreeTrue, bool indicFourTrue)
        {
            if(indicOneTrue == true) indicator1.SetColor("_EmissionColor", new Color(0.1f, 0.8f, 0.1f));
            else indicator1.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));

            if (indicTwoTrue == true) indicator2.SetColor("_EmissionColor", new Color(0.1f, 0.8f, 0.1f));
            else indicator2.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));

            if (indicThreeTrue == true) indicator3.SetColor("_EmissionColor", new Color(0.1f, 0.8f, 0.1f));
            else indicator3.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));

            if (indicFourTrue == true) indicator4.SetColor("_EmissionColor", new Color(0.1f, 0.8f, 0.1f));
            else indicator4.SetColor("_EmissionColor", new Color(0.8f, 0.1f, 0.1f));
        }
    }
}