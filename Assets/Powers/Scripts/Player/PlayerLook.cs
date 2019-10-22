using UnityEngine;

namespace Powers
{
    public class PlayerLook : MonoBehaviour
    {
        public Transform playerBody;
        public PlayerMovement playerController;
        public float mouseSensitivity;
        public bool cursorLock = true;
        public float camLeanSpeed = 0.1f;
        public float camLeanIntensity = 1f;
        public float camSwaySpeed = 0.1f;
        public float camSwayIntensity = 1f;
        public float minXLook = -70f;
        public float maxXLook = 90f;

        private float camLean = 0f;
        private float camSway = 0f;

        private float targetRotCam;
        private float targetRotBody;

        private void Start()
        {
            targetRotCam = transform.localRotation.x; //Get the camera's current rotation.
            targetRotBody = playerBody.localRotation.y; //Get the controller's current rotation.
        }

        void Update()
        {
            if (cursorLock) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;

            RotateCamera();
        }

        void RotateCamera()
        {
            float time = Time.deltaTime * 60;

            float mouseX = Input.GetAxis("Mouse X"); //get mouse X
            float mouseY = Input.GetAxis("Mouse Y"); //get mouse Y

            //multiply the axis by the mouse sensitivity
            float rotAmountX = mouseX * mouseSensitivity;
            float rotAmountY = mouseY * mouseSensitivity;

            //add the difference
            targetRotCam -= rotAmountY;
            targetRotBody += rotAmountX;
            targetRotCam = Mathf.Clamp(targetRotCam, -maxXLook, -minXLook);

            //these are for the cam sway and lean effect
            camSway = Mathf.Lerp(camSway, Input.GetAxis("Mouse X") * camSwayIntensity, time * camSwaySpeed);
            camLean = Mathf.Lerp(camLean, playerController.charController.velocity.magnitude * -Input.GetAxis("Horizontal") * camSwayIntensity, time * camLeanSpeed);

            //clamp these variables
            camSway = Mathf.Clamp(camSway, -camSwayIntensity, camSwayIntensity);
            camLean = Mathf.Clamp(camLean, -camLeanIntensity, camLeanIntensity);

            //set the variables. move the camera.
            transform.transform.localRotation = Quaternion.Euler(targetRotCam, transform.transform.localRotation.y, camSway + camLean);
            playerBody.transform.rotation = Quaternion.Euler(0, targetRotBody, 0);
        }
    }
}
