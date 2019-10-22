using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Andrea
{
    public class DoorController : MonoBehaviour
    {
        public Transform player;
        public NavMeshAgent playerAgent;
        public Transform nextRoom;
        public AreaAccess area;
        float dist;
        bool flagged;

        public bool nextAreaAccessible = true;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        
        void Update()
        {
            dist = Vector3.Distance(player.position, transform.position);
            if (flagged && dist <= 3)
            {
                playerAgent.enabled = false;
                GotoNextRoom();
            }
        }

        void OnMouseDown()
        {
            flagged = true;

        }

        public void GotoNextRoom()
        {
            
            player.position = nextRoom.position;
           

        }
    }
}