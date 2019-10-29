using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Puzzle_Battery : MonoBehaviour
    {
        public string[] updatedDialogue;
        private NPC npc;

        void Start()
        {
            npc = GetComponent<NPC>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.Money)
            {
                Inventory.singleton.Set(Item.Money, false);
                Inventory.singleton.Set(Item.Battery);
                npc.dialogue = updatedDialogue;
            }
        }
    }
}