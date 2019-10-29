using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Petzak
{
    public class Timer : MonoBehaviour
    {
        public GameObject txt;
        public bool running = false;
        public bool clickable = false;
        int current = 10;
        double counter = 0;

        void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.Torch))
                return;

            if (!running)
                running = true;

            if (clickable)
                Inventory.main.Set(Item.Torch, true);
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        void Update()
        {
            if (running)
            {
                counter++;
                if (counter / 60 == Math.Floor(counter / 60))
                {
                    current--;

                    txt.GetComponent<TextMesh>().text = 
                        current > 5 ? current.ToString() : "";

                    if (current == 1)
                    {
                        clickable = true;
                    }
                    else if (current == 0)
                    {
                        clickable = false;
                        counter = 0;
                        running = false;
                        current = 10;
                        txt.GetComponent<TextMesh>().text = "10";
                    }
                }
            }
        }
    }
}