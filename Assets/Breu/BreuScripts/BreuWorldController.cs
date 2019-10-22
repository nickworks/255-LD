using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuWorldControllerr
    {
        private static BreuWorldControllerr _main;//c# field
        public static BreuWorldControllerr main//c# property
        {
            get//public getter
            {
                if (_main == null) _main = new BreuWorldControllerr();//lazy instantiation
                return _main;
            }
            private set//private setter
            {
                _main = value;
            }
        }

        public bool placedPole = false;
        public bool placedHandle = false;

        public bool placedClock = false;
        public bool completedClock = false;

        public bool pressedButton1 = false;
        public bool pressedButton2 = false;
        public bool pressedButton3 = false;
        public bool pressedButton4 = false;

        public bool brokeChains = false;
    }
}