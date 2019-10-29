using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{
    public class NPC : Interactable
    {
        public string[] dialogue;
        public string name;
        public AreaAccess areaUnlock;

        public override void Interact()
        {
            DialogueSystem.Singleton.AddNewDialogue(dialogue, name);
            Inventory.singleton.SetAccess(areaUnlock);
            Debug.Log("Interacting with NPC");
        }
    }
}