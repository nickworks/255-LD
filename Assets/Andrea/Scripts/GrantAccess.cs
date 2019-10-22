using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class GrantAccess : Interactable
    {
        public AreaAccess area;

        public override void Interact()
        {
            if (area != AreaAccess.None)
            {
                Inventory.singleton.SetAccess(area);
                Destroy(gameObject);
            }
            Debug.Log("area should unlock");
        }
    }
}