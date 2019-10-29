using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class PuzzleChestKey : MonoBehaviour
    {
        public GameObject key;
        public GameObject tree;
      
        private void OnMouseDown()
        {
            if (Inventory.main.HasItem(Item.Axe))
            {
                key.SetActive(false);
                tree.SetActive(false);
                Inventory.main.Set(Item.ChestKey);
            }
        }
    }
}
