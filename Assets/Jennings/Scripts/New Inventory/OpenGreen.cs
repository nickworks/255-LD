using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Jennings {
    public class OpenGreen : MonoBehaviour {

        public GameObject GreenKey;
        public GameObject NeverMoreGr;
        public GameObject NoMoreGreenKey;

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.GreenKey))
            {
                GreenKey.SetActive(true);
                Inventory.main.Set(Item.GreenKey, false);
                if (NeverMoreGr != null)
                {
                    NeverMoreGr.SetActive(false);
                }
                if (NoMoreGreenKey != null)
                {
                    NoMoreGreenKey.SetActive(false);
                }

            }
        }
    }
}