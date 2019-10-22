using UnityEngine;

namespace Powers
{
    public class ObjectUI : MonoBehaviour
    {
        public CanvasGroup infoGroup;

        private float alpha;
        private float velocity;

        private bool selected = false;

        void Update()
        {
            if(selected == true) alpha = Mathf.SmoothDamp(alpha, 1f, ref velocity, 0.5f);
            else alpha = Mathf.SmoothDamp(alpha, 0f, ref velocity, 0.5f);
            infoGroup.alpha = alpha;
        }

        public void OnPointerEnter()
        {
            selected = true;
        }

        public void OnPointerExit()
        {
            selected = false;
        }
    }
}
