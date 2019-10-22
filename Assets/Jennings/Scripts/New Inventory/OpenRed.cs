using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Jennings {
    public class OpenRed : MonoBehaviour {

        public GameObject RedKey;
        public GameObject NeverMoreRe;
        public GameObject NoMoreRedKey;

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.RedKey))
            {
                RedKey.SetActive(true);
                Inventory.main.Set(Item.RedKey, false);
                if (NeverMoreRe != null)
                {
                    NeverMoreRe.SetActive(false);
                }
                if (NoMoreRedKey != null)
                {
                    NoMoreRedKey.SetActive(false);
                }

            }
        }
    }
}
