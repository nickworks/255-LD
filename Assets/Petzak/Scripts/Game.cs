using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    class Game
    {
        public static readonly Game main = new Game();

        public bool LowerBridge = false;
        public bool BridgeLowered = false;
        public bool MainDoorLocked = true;
        public int CurrentCamera = 1;

        public bool Post1Topped = false;
        public bool Post2Topped = false;

        private Game()
        {
            //var cameras = new Camera[11];
            //Camera.GetAllCameras(cameras);

            //foreach (Camera c in cameras)
            //{
            //    if (c == null)
            //        continue;

            //    if (c.name.Replace("Cam", "") == "1")
            //    {
            //        c.depth = 2;
            //        main.CurrentCamera = 1;
            //    }
            //    else
            //    {
            //        c.depth = 1;
            //    }
            //}
        }
    }
}
