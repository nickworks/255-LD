using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Lasso : MonoBehaviour
    {
        void OnMouseDown()
        {
            //print("sling");
            Inventory.main.Set(Item.Lasso);
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