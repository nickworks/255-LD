using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class Puzzle_Cat : MonoBehaviour
    {
        public string[] updatedDialogue;
        //private NPC npc;

        void Start()
        {

        }
        void OnMouseDown()
        {
            //Inventory.singleton.Set(Item.Cat);
            if (Inventory.singleton.itemSelected == Item.Fish)
            {
                Inventory.singleton.Set(Item.Fish, false);
                Inventory.singleton.Set(Item.Cat);
                Destroy(gameObject);
                //npc.dialogue = updatedDialogue;
            }

        }
    }
}