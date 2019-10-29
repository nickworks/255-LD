using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class Door : MonoBehaviour
    {
        bool clicked = false;
        public int fromCamera;
        public int toCamera;

        void OnMouseDown()
        {
            clicked = true;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (clicked)
            {
                if ((gameObject.name == "BlueDoor" && Inventory.main.selectedItem != Item.BlueKey) ||
                    (gameObject.name == "RedDoor" && Inventory.main.selectedItem != Item.RedKey) ||
                    (gameObject.name == "PurpleDoor" && Inventory.main.selectedItem != Item.PurpleKey))
                {
                    clicked = false;
                    return;
                }

                var cameras = new Camera[11];
                Camera.GetAllCameras(cameras);

                foreach (Camera c in cameras)
                {
                    if (c == null)
                    {
                        //print("null");
                        continue;
                    }

                    if (c.name.Replace("Cam", "") == toCamera.ToString())
                    {
                        if (fromCamera == 6 && Game.main.MainDoorLocked)
                            continue;

                        c.depth = 2;
                        Game.main.CurrentCamera = toCamera;
                    }
                    else
                    {
                        c.depth = 1;
                    }
                }

                clicked = false;
            }
        }
    }
}