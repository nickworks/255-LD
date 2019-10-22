using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powers
{
    public class Lev2_HubSceneLoader : MonoBehaviour
    {
        public string sceneName;
        public PlayerMovement playerMove;
        public PlayerLook playerLook;
        public Animator door;
        public UnityEngine.UI.Image fadeToBlack;

        [Space(10)]
        public GameObject loadingPrefab;

        private bool inTrigger = false;

        private float fadeAlpha = 0f;
        private float fadeVelocity = 0f;
        private bool doorClosing = false;
        private bool eventStarted = false;

        // Update is called once per frame

        private void Update()
        {
            if(inTrigger)
            {
                //stop player from moving and confusing game
                playerMove.enabled = false;
                playerLook.enabled = false;

                if(!doorClosing) door.Play("DoorClose", 0, 0f);
                doorClosing = true;

                //fade camera
                if (fadeAlpha <= 0.99)
                {
                    fadeAlpha = Mathf.SmoothDamp(fadeAlpha, 1f, ref fadeVelocity, 1f);
                    fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, fadeAlpha);
                }
                else if (!eventStarted)
                {
                    GameObject loading = Instantiate(loadingPrefab, new Vector3(0, 100, 0), Quaternion.Euler(0, 0, 0));
                    loading.GetComponent<LoadingScript>().sceneName = sceneName;
                    eventStarted = true;
    }
            }

        }

        void OnTriggerEnter()
        {
            inTrigger = true;
        }
    }
}