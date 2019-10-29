using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Puzzle_Money : MonoBehaviour
    {
        public string[] updatedDialogue;
        private NPC npc;

        void Start()
        {
            npc = GetComponent<NPC>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.Cat)
            {
                Inventory.singleton.Set(Item.Cat, false);
                Inventory.singleton.Set(Item.Money);
                npc.dialogue = updatedDialogue;
            }
        }
    }
}