using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreuWeek7
{
    public class Inventory
    {
        public readonly static Inventory main = new Inventory();

        public bool hasKey = false;

        private Inventory() { }
    }
}
