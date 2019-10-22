using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Puzzle_Sword : MonoBehaviour
    {
        public string[] updatedDialogue;
        private NPC npc;

        void Start()
        {
            npc = GetComponent<NPC>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.Sword)
            {
                Inventory.singleton.Set(Item.Sword, false);
                Inventory.singleton.Set(Item.Fish);
                npc.dialogue = updatedDialogue;
            }
        }
    }
}
