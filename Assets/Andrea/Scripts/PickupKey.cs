using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class PickupKey : MonoBehaviour
    {
        public Transform player;
        public float dist;

        bool flagged;

        void OnMouseDown()
        {
            flagged = true;            
        }
        void Update()
        {
            dist = Vector3.Distance(player.position, transform.position);
            if (flagged && dist <= 3)
            {
                Pickup();
            }

            if (Inventory.singleton.hasKey)
            {
                Destroy(gameObject);
            }
        }

        void Pickup()
        {
            Inventory.singleton.hasKey = true;
            Destroy(gameObject);
        }

    }
}