using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class PuzzleChest : MonoBehaviour
    {
        public GameObject chest;

        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.Shovel))
            {
                chest.SetActive(true);
                
            }
        }
    }
}
