using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Jennings {
    public class OpenOrange : MonoBehaviour {

        public GameObject OrangeKey;
        public GameObject NeverMoreOr;
        public GameObject NoMoreOrangeKey;

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.OrangeKey))
            {
                OrangeKey.SetActive(true);
                Inventory.main.Set(Item.OrangeKey, false);
                if (NeverMoreOr != null)
                {
                    NeverMoreOr.SetActive(false);
                }
                if (NoMoreOrangeKey != null)
                {
                    NoMoreOrangeKey.SetActive(false);
                }

            }
        }
    }
}