using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Andrea
{
    public class Puzzle_Bus_Down : MonoBehaviour
    {
        public GameObject player;
        public GameObject teleportLoc;

        private NavMeshAgent playerAgent;

        void Start()
        {
            playerAgent = player.GetComponent<NavMeshAgent>();
        }
        void OnMouseDown()
        {
            if (Inventory.singleton.itemSelected == Item.BusPass)
            {
                playerAgent.enabled = false;
                player.transform.position = teleportLoc.transform.position;
                //playerAgent.enabled = true;
                //playerAgent.SetDestination(teleportLoc.transform.position);
            }
        }
    }
}