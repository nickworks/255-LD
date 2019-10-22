using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Myles
{
    public class InventoryGUI : MonoBehaviour
    {
        public Text textHint;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Inventory.main.itemBeingUsed = Item.None;
            }

            if (Inventory.main.itemBeingUsed == Item.None)
            {
                textHint.text = "";

            }
            else
            {
                switch (Inventory.main.itemBeingUsed)
                {
                    case Item.None:
                        break;
                    case Item.Paper:
                        textHint.text = $"Quick! You have 5 minutes to open the gate and escape the forest!";
                        break;
                    case Item.Shovel:
                        textHint.text = $"Use the {Inventory.main.itemBeingUsed} to dig where the X is.";
                        break;
                    case Item.ChestKey:
                        textHint.text = $"Use the {Inventory.main.itemBeingUsed} to open the chest you dug up.";
                        break;
                    case Item.Axe:
                        textHint.text = $"Use the {Inventory.main.itemBeingUsed} to cut down the tree that holds a key.";
                        break;
                    case Item.Stick:
                        textHint.text = $"Use {Inventory.main.itemBeingUsed} on ...";
                        break;
                    case Item.GateKey:
                        textHint.text = $"You found this in the chest. Now you can escape the forest!";
                        break;
                }
                
            }

        }
    }
}
