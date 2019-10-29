using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Post : MonoBehaviour
    {
        public GameObject sphere;
        public GameObject blueKey;

        void OnMouseDown()
        {
            bool ret = false;
            if (gameObject.name == "Post1" && Game.main.Post1Topped)
            {
                ret = true;
                Game.main.Post1Topped = false;
            }

            else if (gameObject.name == "Post2" && Game.main.Post2Topped)
            {
                ret = true;
                Game.main.Post2Topped = false;
            }

            if (ret)
            {
                sphere.SetActive(false);
                if (!Inventory.main.HasItem(Item.Rock1))
                    Inventory.main.Set(Item.Rock1);
                else if (!Inventory.main.HasItem(Item.Rock2))
                    Inventory.main.Set(Item.Rock2);
                else if (!Inventory.main.HasItem(Item.Rock3))
                    Inventory.main.Set(Item.Rock3);
                return;
            }

            Item si = Inventory.main.selectedItem;
            if (si == Item.Rock1 || si == Item.Rock2 || si == Item.Rock3)
            {
                Inventory.main.Set(si, false);
                if (gameObject.name == "Post1")
                {
                    sphere.SetActive(true);
                    Game.main.Post1Topped = true;
                }
                else
                {
                    sphere.SetActive(true);
                    Game.main.Post2Topped = true;
                }

                if (Game.main.Post1Topped && Game.main.Post2Topped)
                {
                    //var o = GameObject.FindGameObjectWithTag("bk");
                    blueKey.SetActive(true);
                }
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