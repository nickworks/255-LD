using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Petzak
{
    public class ItemGUI : MonoBehaviour
    {
        public Item item;
        private Image image;

        void Start()
        {
            image = GetComponent<Image>();
        }

        void Update()
        {
            image.enabled = Inventory.main.HasItem(item);
        }

        public void HandleClick()
        {
            

            Inventory.main.selectedItem = item;
        }
    }
}