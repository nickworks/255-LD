using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powers
{
    public class Lev3_CloseRoomOne : MonoBehaviour
    {
        private bool inTrigger = false;
        private bool eventStarted = false;

        public Animator door;
        public GameObject roomOne;
        public GameObject roomTwo;

        // Update is called once per frame
        void Update()
        {
            if (inTrigger & !eventStarted)
            {
                StartCoroutine(CloseOffRoomOne());
                eventStarted = true;
            }
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.tag == "Player") inTrigger = true;
        }

        IEnumerator CloseOffRoomOne()
        {
            roomTwo.SetActive(true);
            door.Play("DoorClose");
            yield return new WaitForSeconds(2);
            roomOne.SetActive(false);
            Destroy(gameObject);
        }
    }
}
