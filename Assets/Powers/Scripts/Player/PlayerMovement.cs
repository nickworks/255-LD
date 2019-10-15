using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powers
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController charController;
        public GameObject camHandler;

        [Header("Character Speed")]
        public float walkSpeed = 4.0f;
        public bool allowRun = true;
        public float runSpeed = 8.0f;
        public float crouchSpeed = 3.0f;

        [Header("Character Jump")]
        public float jumpSpeed = 8.0f;
        public int jumpLimiter = 0;
        public float crouchDownSpeed = 0.1f;
        public float gravity = 10.0f;
        public float bouncePrevention = -5f;

        [Header("Character Crouch Settings")]
        public float controllerDefaultHeight = 1.8f;
        public float controllerCrouchHeight = 0.9f;
        public float camDefaultHeight = 0.5f;
        public float camCrouchHeight = 0.25f;

        [HideInInspector]
        public float speed = 0f;
        [HideInInspector]
        public bool isJumping = false;
        [HideInInspector]
        public bool isGrounded = true;
        [HideInInspector]
        public bool isCrouching = false;
        [HideInInspector]
        public bool isSprinting = false;
        [HideInInspector]
        public Vector3 moveDirection = Vector3.zero;

        private bool checkCeiling = false;

        private float yDirection = 0;
        private float jumpTimer = 0;
        private float velocityY = 0.0f;

        private float controllerCenter = 0;
        private float controllerHeight = 0f;
        private float camHeight = 0f;

        private float heightVelocity = 0;
        private float centerVelocity = 0;
        private float camVelocity = 0;

        float slopeAngle = 0;

        float time;

        void Start()
        {
            controllerHeight = controllerDefaultHeight;
            camHeight = camDefaultHeight;
            time = Time.deltaTime * 60;

            speed = 0f;
        }

        void Update()
        {
            time = Time.deltaTime * 60;

            //checks to see what state the player is in, such as if he's grounded or crouched and under an object
            #region Player State Check

            //detect if player is on the ground
            isGrounded = charController.isGrounded;

            //if player is crouching, detect if the player is under an object
            if (isCrouching)
            {
                checkCeiling = Physics.Raycast(transform.position + new Vector3(charController.radius, 0, 0), Vector3.up, controllerDefaultHeight - controllerCrouchHeight + 0.1f);
                if (!checkCeiling) checkCeiling = Physics.Raycast(transform.position + new Vector3(-charController.radius, 0, 0), Vector3.up, controllerDefaultHeight - controllerCrouchHeight + 0.1f);
                if (!checkCeiling) checkCeiling = Physics.Raycast(transform.position + new Vector3(0, 0, charController.radius), Vector3.up, controllerDefaultHeight - controllerCrouchHeight + 0.1f);
                if (!checkCeiling) checkCeiling = Physics.Raycast(transform.position + new Vector3(0, 0, -charController.radius), Vector3.up, controllerDefaultHeight - controllerCrouchHeight + 0.1f);
            }

            #endregion

            //check inputs to see what state the player is in, and sets the speed and player height dependent on it
            #region Input Checks

            //set player height depending on if player is crouching or not
            if (Input.GetButton("Fire1") && !isJumping || isCrouching && checkCeiling && !isJumping)
            {
                crouchFunction(controllerCrouchHeight, camCrouchHeight);
                isCrouching = true;
            }
            else
            {
                crouchFunction(controllerDefaultHeight, camDefaultHeight);
                isCrouching = false;
            }

            //set player speed depending on player input
            if (Input.GetButton("Fire3") && allowRun && !isCrouching) speed = Mathf.SmoothDamp(speed, runSpeed, ref velocityY, 0.2f);
            else if (isCrouching) speed = Mathf.SmoothDamp(speed, crouchSpeed, ref velocityY, 0.1f);
            else if (!isCrouching && !isSprinting) speed = Mathf.SmoothDamp(speed, walkSpeed, ref velocityY, 0.2f);
            else speed = Mathf.SmoothDamp(speed, 0, ref velocityY, 0.1f);

            #endregion

            //checks input to get the player velocity, then multiplies it by speed
            #region Get Movement Vector
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")); //grab the input on the horizontal and vertical axis
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1); //clamp the magnitude
            moveDirection = transform.TransformDirection(moveDirection); //set this vector to be based on player rotation

            //multiply the move vector by the speed
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            #endregion

            //this checks what calculations to do in terms of the Y-velocity
            #region Y-Velocity Calculations

            if (isGrounded)
            {
                isJumping = false;
                //The next if checks to see if 1) the player has pressed the jump button, 2) is the player crouching,
                // and 3) if the angle of the slope the player is on is not greater than the character controller's slope
                // limit. The last part is important for ensuring the player doesn't just jump up slopes they can't walk up.
                if (Input.GetButtonDown("Jump") && !isCrouching && (slopeAngle < charController.slopeLimit))
                {
                    yDirection = jumpSpeed;
                    isJumping = true;
                }
                else
                {
                    jumpTimer++;
                    jumpTimer = Mathf.Clamp(jumpTimer, 0, jumpLimiter);
                    if (Physics.Raycast(transform.position, Vector3.down, charController.height + 0.1f)) yDirection = bouncePrevention;
                    else yDirection = 0f;
                }
            }
            else
            {
                if (isGrounded & !isJumping) yDirection = 0f;
                yDirection += gravity * Time.deltaTime;
            }
            Mathf.Clamp(yDirection, -60, 60);
            moveDirection.y = yDirection;

            #endregion

            //this sets all the variables that this script has been building up to
            #region Set Variables
            charController.height = controllerHeight;
            charController.center = new Vector3(charController.center.x, controllerCenter, charController.center.z);
            camHandler.transform.localPosition = new Vector3(camHandler.transform.localPosition.x, camHeight, camHandler.transform.localPosition.z);

            charController.Move(moveDirection * Time.deltaTime);

            #endregion
        }

        void crouchFunction(float desiredControllerHeight, float desiredCamHeight)
        {
            controllerHeight = Mathf.SmoothDamp(controllerHeight, desiredControllerHeight, ref heightVelocity, time * 0.4f); //Transitions controller height.
            controllerCenter = Mathf.SmoothDamp(controllerCenter, (desiredControllerHeight - controllerDefaultHeight) / 2, ref centerVelocity, time * 0.4f); //Transitions controller center.
            camHeight = Mathf.SmoothDamp(camHeight, desiredCamHeight, ref camVelocity, time * 0.4f); //Transitions cam height.
        }

        void OnControllerColliderHit(ControllerColliderHit hit) //this is used to detect the slope angle of the floor
        {
            slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
        }
    }

}