using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Caughman 
{     
    public class Inventory
        {
        public readonly static Inventory main = new Inventory();

        public bool hasKey = false;
        public bool hasDrawerKey = false;

            private Inventory()
            {

            }

        }//End Inventory
}
