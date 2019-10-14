using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings {


    public class Door1 : MonoBehaviour {

        public Camera cameraThisRoom;
        public Camera cameraNextRoom;


        void OnMouseDown()
        {
            print("Door1 clicked");

            cameraThisRoom.gameObject.SetActive(false);
            cameraNextRoom.gameObject.SetActive(true);
        }
    }
}
