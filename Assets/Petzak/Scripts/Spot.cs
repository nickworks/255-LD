using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Spot : MonoBehaviour
    {
        void OnMouseDown()
        {
            //print("sling");
            if (Inventory.main.selectedItem == Item.Lasso)
            {
                Inventory.main.Set(Item.Slingshot);
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
            //print("asdf");
        }
    }

}