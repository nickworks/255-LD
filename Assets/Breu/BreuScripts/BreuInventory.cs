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

        }

        #region Tutorial items
        public bool unlockedInventory = false;
        public bool unlockedChat = false;

        public bool tutKey = false;
        public bool tutDoor = false;
        #endregion

        #region Main game items
        public bool foundKey = false;
        public bool hasKey = false;
        public bool usingKey = false;

        public bool foundHandle = false;
        public bool hasHandle = false;
        public bool usingHandle = false;

        public bool foundPole = false;
        public bool hasPole = false;
        public bool usingPole = false;

        public bool hasLever = false;
        public bool usingLever = false;

        public bool foundOil = false;
        public bool hasOil = false;
        public bool usingOil = false;

        public bool foundClock = false;
        public bool hasClock = false;
        public bool usingClock = false;

        public bool foundCutter = false;
        public bool hasCutter = false;
        public bool usingCutter = false;

        public bool foundMallet = false;
        public bool hasMallet = false;
        public bool usingMallet = false;
        #endregion

        public static void setUseItem()
        {
            main.usingClock = false;
            main.usingCutter = false;
            main.usingHandle = false;
            main.usingKey = false;
            main.usingLever = false;
            main.usingOil = false;
            main.usingPole = false;
        }
    }
}