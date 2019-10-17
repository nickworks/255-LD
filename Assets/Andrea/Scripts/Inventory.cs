using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Inventory
    {
        public readonly static Inventory singleton = new Inventory();

        public bool hasKey = false;

        private Inventory()
        {

        }
    }

}