using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens
{
    public class DresserCode : MonoBehaviour
    {
        //public GameObject
        public GameObject[] drawers;
        public GameObject drawertoUnlock;
        private Drawer a;
        private Drawer b;
        private Drawer c;
        private Drawer d;
        private Drawer e;
        private Drawer f;
        private Drawer g;
        private Drawer h;
        private bool hasCompletedPuzzle = false;

        void Start()
        {
            a = drawers[0].GetComponent<Drawer>();
            b = drawers[1].GetComponent<Drawer>();
            c = drawers[2].GetComponent<Drawer>();
            d = drawers[3].GetComponent<Drawer>();
            e = drawers[4].GetComponent<Drawer>();
            f = drawers[5].GetComponent<Drawer>();
            g = drawers[6].GetComponent<Drawer>();
            h = drawers[7].GetComponent<Drawer>();

        }
        // Update is called once per frame
        void Update()
        {
            if (!hasCompletedPuzzle)
            {
                if (d.isOpen)
                {
                    if (!a.isOpen && !b.isOpen && !c.isOpen && e.isOpen && !f.isOpen && g.isOpen && !h.isOpen)
                    {
                        hasCompletedPuzzle = true;
                        drawertoUnlock.GetComponent<Drawer>().isLocked = false;
                        GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>().displayMessage("You hear a *click*");
                    }

                }
            }
        }
    }
}