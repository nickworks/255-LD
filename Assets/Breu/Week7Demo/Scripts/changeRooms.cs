using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreuWeek7
{
    public class changeRooms : MonoBehaviour
    {
        public Camera cameraThisRoom;
        public Camera cameraNextRoom;
        public bool GoToNextRoomOnClick;

        void OnMouseDown()
        {
            if (GoToNextRoomOnClick == true)
            {
                GoToNextRoom();
            }            
        }

        public void GoToNextRoom()
        {
            cameraThisRoom.gameObject.SetActive(false);
            cameraNextRoom.gameObject.SetActive(true);
        }
    }
}