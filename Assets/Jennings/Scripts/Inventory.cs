using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {

    public class Inventory
    {
        public readonly static Inventory main = new Inventory();

        public bool hasKey1 = false;
        public bool hasKey2 = false;
        public bool hasKey3 = false;

        public Inventory()
        {

        }

    }
}
