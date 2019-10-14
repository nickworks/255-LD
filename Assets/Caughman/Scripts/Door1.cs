using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caughman
{
    [RequireComponent(typeof(ChangeRoom))]
    public class Door1 : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if (Inventory.main.hasKey)
            {
                GetComponent<ChangeRoom>().gotoNextRoom();
                //TODO: Change rooms
            }
        }
    }
}
