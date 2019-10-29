using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public class CameraController : MonoBehaviour
    {
        //public static CameraController main = new CameraController();
        //public Camera[] cameras;
        public static int currentCameraIndex;

        private CameraController()
        {
            //Camera.GetAllCameras(cameras);
        }

        //public static CameraController GetInstance()
        //{
        //    if (main == null)
        //        main = new CameraController();
        //    return main;
        //}

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}