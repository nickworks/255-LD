using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{ 
    public class ActionItem : Interactable
    { 
        public override void Interact()
        {
            Debug.Log("Interacting with base ActionItem");
        }
    }
}