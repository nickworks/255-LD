using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {

    [RequireComponent(typeof(ChangeRooms))]
    public class Door2 : MonoBehaviour {
        
        void OnMouseDown()
        {
            // Inventory is the public class, main is the singleton instance of inventory in the class, with hasKey being it's boolean property
            if(InventoryOG.main.hasKey1)
            {
                GetComponent<ChangeRooms>().GotoNextRoom();

            }
        }
    }
}
