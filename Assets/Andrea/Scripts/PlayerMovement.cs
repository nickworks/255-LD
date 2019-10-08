using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Andrea
{
    public class PlayerMovement : MonoBehaviour
    {
        public NavMeshAgent agent;
        public float inputHoldDelay = .5f;

        private WaitForSeconds inputHoldWait;
        private Vector3 destinationPosition;
        private bool handleInput = true;
        //private Interactable currentInteractable;
        private const float stopDistanceProportion = 0.1f;

        private void Start()
        {
            inputHoldWait = new WaitForSeconds(inputHoldDelay);
            destinationPosition = transform.position;
        }

        private void Update()
        {
            if (agent.pathPending)
                return;


            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }

            /*if ((agent.remainingDistance <= agent.stoppingDistance * stopDistanceProportion) &&  currentInteractable)
            {
                transform.rotation = currentInteractable.interactionLocation.rotation;
                currentInteractable.Interact();
                currentInteractable = null;
                StartCoroutine(WaitForInteraction());
            }*/
        }

        public void OnInteractableClick (Interactable interactable)
        {
            if (!handleInput)
            {
                return;
            }

            //currentInteractable = interactable;
            //destinationPosition = currentInteractable.interactionLocation.position;

            agent.destination = destinationPosition;
        }

        private IEnumerator WaitForInteraction()
        {
            handleInput = false;

            yield return inputHoldWait;

            while(!agent.hasPath)
            {
                yield return null;
            }

            handleInput = true;
        }
    }
}