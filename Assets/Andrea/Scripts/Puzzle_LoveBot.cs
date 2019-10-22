using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Puzzle_LoveBot : MonoBehaviour
    {
        public string[] updatedDialogue;
        private NPC npc;

        void Start()
        {
            npc = GetComponent<NPC>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.Battery)
            {
                Inventory.singleton.Set(Item.Battery, false);
                npc.dialogue = updatedDialogue;
            }
        }
    }
}