using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class SetUsing : MonoBehaviour
    {
        public void Key()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingKey = true;
        }
        public void Handle()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingHandle = true;
        }
        public void Pole()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingPole = true;
        }
        public void Oil()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingOil = true;
        }
        public void Cutter()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingCutter = true;
        }
        public void Mallet()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingMallet = true;
        }
        public void Clock()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingClock = true;
        }
        public void Lever()
        {
            BreuInventory.setUseItem();
            BreuInventory.main.usingLever = true;
        }


        public void HandleOnPole()
        {
            if (BreuInventory.main.usingHandle == true)
            {
                GetLever();
            }
        }
        public void PoleOnHandle()
        {
            if (BreuInventory.main.usingPole == true)
            {
                GetLever();
            }
        }
        public void GetLever()
        {
            
                BreuInventory.main.hasHandle = false;
                BreuInventory.main.hasPole = false;
                BreuInventory.main.hasLever = true;
            
        }

    }
}