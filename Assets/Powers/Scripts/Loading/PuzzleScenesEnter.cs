using System.Collections;
using UnityEngine;

namespace Powers
{
    public class PuzzleScenesEnter : MonoBehaviour
    {
        public Animator door;
        public Animation player;
        public UnityEngine.UI.Image fadeToBlack;

        private float fadeAlpha = 0f;
        private float fadeVelocity = 0f;

        private bool eventStarted = false;

        private void Start()
        {
            fadeAlpha = 1;
        }

        private void Update()
        {
            //fade in camera
            if (fadeAlpha >= 0.02 && !eventStarted)
            {
                fadeAlpha = Mathf.SmoothDamp(fadeAlpha, 0f, ref fadeVelocity, 1f);
                fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, fadeAlpha);
            }
            //start event once camera faded in
            else if(!eventStarted)
            {
                fadeAlpha = 0;
                StartCoroutine(EnterEvent());
                eventStarted = true;
            }
        }

        //plays animations in scene for entering room
        IEnumerator EnterEvent()
        {
            door.Play("DoorOpen", 0, 0f);
            yield return new WaitForSeconds(2f);

            player.Play("cutscene_playerEnterPuzzle");
            yield return new WaitForSeconds(0.5f);

            door.Play("DoorClose", 0, 0f);
            yield return new WaitForSeconds(2f);

            Destroy(gameObject);

            yield break;
        }
    }
}

