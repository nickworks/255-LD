using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Andrea
{
    public class Interactable : MonoBehaviour
    {
        public float stoppingDistance = 3f;

        [HideInInspector]
        public NavMeshAgent playerAgent;
        private bool hasInteracted;

        public virtual void MoveToInteraction(NavMeshAgent playerAgent)
        {
            hasInteracted = false;
            this.playerAgent = playerAgent;
            playerAgent.stoppingDistance = stoppingDistance;
            playerAgent.destination = this.transform.position;
        }

        void Update()
        {
            if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
            {
                if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
                {
                    Interact();
                    LookTowardObject();
                    hasInteracted = true;
                }
            }
        }

        void LookTowardObject()
        {
            playerAgent.updateRotation = false;
            Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
            playerAgent.transform.LookAt(lookDirection);
            playerAgent.updateRotation = true;
        }

        public virtual void Interact()
        {
            Debug.Log("Interacting with base class.");

        }
    }
}