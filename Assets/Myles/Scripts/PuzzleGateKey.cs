using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class PuzzleGateKey : MonoBehaviour
    {
        

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.ChestKey))
            {
               
                Inventory.main.Set(Item.GateKey);
            }
        }
    }
}
