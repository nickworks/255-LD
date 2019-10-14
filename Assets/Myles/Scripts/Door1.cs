using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class Door1 : MonoBehaviour
    {
        public Camera cameraThisRoom;
        public Camera cameraNextRoom;

        void OnMouseDown()
        {
            //print("door 1 clicked");

            cameraThisRoom.gameObject.SetActive(false);
            cameraNextRoom.gameObject.SetActive(true);

        }
    }
}
