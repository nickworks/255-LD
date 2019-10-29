using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Lever : MonoBehaviour
    {
        public int num;
        public bool pulled = false;

        void OnMouseDown()
        {
            if (pulled)
                return;

            if (num == 0 
                && Inventory.main.selectedItem == Item.Slingshot
                && Game.main.CurrentCamera == 4)
            {
                if (Inventory.main.HasItem(Item.Rock1))
                    Flip1(Item.Rock1);
                else if (Inventory.main.HasItem(Item.Rock2))
                    Flip1(Item.Rock2);
                else if (Inventory.main.HasItem(Item.Rock3))
                    Flip1(Item.Rock3);
            }
            else if (num == 1 
                    && Inventory.main.selectedItem == Item.Lasso 
                    && Game.main.CurrentCamera == 6)
                Flip2();
        }

        private void Flip1(Item i)
        {
            Game.main.LowerBridge = true;
            Inventory.main.Set(i, false);
            gameObject.transform.transform.Rotate(90, 0, 0, Space.World);
            gameObject.transform.transform.Translate(0, 0, 3, Space.World);
            pulled = true;
            Inventory.main.selectedItem = Item.None;
        }

        private void Flip2()
        {
            Game.main.MainDoorLocked = false;
            gameObject.transform.transform.Rotate(0, 0, -90, Space.World);
            gameObject.transform.transform.Translate(0, -3, 0, Space.World);
            pulled = true;
            Inventory.main.selectedItem = Item.None;
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