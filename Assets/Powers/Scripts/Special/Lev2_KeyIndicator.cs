using UnityEngine;

namespace Powers
{
    public class Lev2_KeyIndicator : MonoBehaviour
    {

        public CanvasGroup canvasGroup;

        private float canvasAlpha;
        private float canvasVelocity;

        private bool inTrigger;

        private void Update()
        {
            //fade in the canvas indicating which key the room is for
            if (inTrigger) canvasAlpha = Mathf.SmoothDamp(canvasAlpha, 1, ref canvasVelocity, 0.5f);
            else canvasAlpha = Mathf.SmoothDamp(canvasAlpha, 0, ref canvasVelocity, 0.5f);
            canvasGroup.alpha = canvasAlpha;
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.tag == "Player") inTrigger = true;
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Player") inTrigger = false;
        }
    }
}
