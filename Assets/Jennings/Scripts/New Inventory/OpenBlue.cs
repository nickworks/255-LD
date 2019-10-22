using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Jennings {
    public class OpenBlue : MonoBehaviour {

        public GameObject BlueKey;
        public GameObject NeverMoreBl;
        public GameObject NoMoreBlueKey;

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.BlueKey))
            {
                BlueKey.SetActive(true);
                Inventory.main.Set(Item.BlueKey, false);
                if (NeverMoreBl != null)
                {
                    NeverMoreBl.SetActive(false);
                }
                if (NoMoreBlueKey != null)
                {
                    NoMoreBlueKey.SetActive(false);
                }

            }
        }
    }
}
