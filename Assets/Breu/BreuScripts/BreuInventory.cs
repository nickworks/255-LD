using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuInventory
    {
        private static BreuInventory _main;//c# field
        public static BreuInventory main//c# property
        {
            get//public getter
            {
                if (_main == null) _main = new BreuInventory();//lazy instantiation
                return _main;
            }
            private set//private setter
            {
                _main = value;
            }
        }

        public static void Reset()
        {
            main.foundKey = false;
            main.tutorialKey = false;
        }

        public bool tutorialKey = false;

        public bool foundKey = false;
        
    }
}