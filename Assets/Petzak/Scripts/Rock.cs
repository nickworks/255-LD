using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Rock : MonoBehaviour
    {
        void OnMouseDown()
        {
            print("lever click");
            if (!Inventory.main.HasItem(Item.Rock1))
                Inventory.main.Set(Item.Rock1);
            else if (!Inventory.main.HasItem(Item.Rock2))
                Inventory.main.Set(Item.Rock2);
            else if (!Inventory.main.HasItem(Item.Rock3))
                Inventory.main.Set(Item.Rock3);
            Destroy(gameObject);
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