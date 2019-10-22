using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrea
{
    public class Puzzle_ArcadeTicket : MonoBehaviour
    {
        public string[] updatedDialogue;
        private NPC npc;

        void Start()
        {
            npc = GetComponent<NPC>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.Ticket)
            {
                Inventory.singleton.Set(Item.Ticket, false);
                Inventory.singleton.Set(Item.BusPass);
                npc.dialogue = updatedDialogue;
            }
        }

    }
}