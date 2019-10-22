using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Petzak
{
    public class InventoryGUI : MonoBehaviour
    {
        public Text textHint;

        //public Image imgPants;
        //public Image imgShirt;
        //public Image imgGloves;

        void OnMouseDown()
        {
            print("asdf");
        }

        // Start is called before the first frame update
        void Start()
        {
            Inventory.main.Set(Item.Shirt);
            Inventory.main.Set(Item.Pants);
        }

        // Update is called once per frame
        void Update()
        {
            //if (Inventory.main.selectedItem == Item.None)
            //{
            //    textHint.text = "";
            //}
            //else
            //{
            //    textHint.text = $"Use {Inventory.main.selectedItem} on ...";
            //}
        }
    }
}