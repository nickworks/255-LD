using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public class DoorController : MonoBehaviour
    {
        public Transform player;
        public Transform nextRoom;

        public bool nextAreaAccessible = true;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDown()
        {
            if (nextAreaAccessible)
            {
                GotoNextRoom();
            }
            
        }

        public void GotoNextRoom()
        {
            player.position = nextRoom.position;
        }
    }
}