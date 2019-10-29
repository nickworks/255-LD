using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{

    public class Key : MonoBehaviour
    {
        void OnMouseDown()
        {
            if (gameObject.name == "BlueKey")
            {
                Inventory.main.Set(Item.BlueKey);
                Destroy(gameObject);
            }
            else if (gameObject.name == "RedKey" && Inventory.main.selectedItem == Item.Slingshot)
            {
                if (!Inventory.main.HasItem(Item.Rock1) 
                    && !Inventory.main.HasItem(Item.Rock2)
                    && !Inventory.main.HasItem(Item.Rock3))
                return;

                Inventory.main.Set(Item.RedKey);

                if (Inventory.main.HasItem(Item.Rock1))
                    Inventory.main.Set(Item.Rock1, false);
                else if (Inventory.main.HasItem(Item.Rock2))
                    Inventory.main.Set(Item.Rock2, false);
                else if (Inventory.main.HasItem(Item.Rock3))
                    Inventory.main.Set(Item.Rock3, false);
                Inventory.main.selectedItem = Item.None;
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}