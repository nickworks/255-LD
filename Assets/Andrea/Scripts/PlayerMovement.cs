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


            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                GetInteraction();
            }

        }

        public void GetInteraction ()
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (!agent.enabled)
                {
                    agent.enabled = true;
                    return;
                }
                GameObject interactedObject = hit.collider.gameObject;
                if (interactedObject.tag == "Interactable Object")
                {
                    interactedObject.GetComponent<Interactable>().MoveToInteraction(agent);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    agent.destination = hit.point;
                }
                
            }
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