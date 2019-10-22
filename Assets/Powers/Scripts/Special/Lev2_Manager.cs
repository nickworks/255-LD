using UnityEngine;
using UnityEngine.Events;

namespace Powers
{
    public class Lev2_Manager : MonoBehaviour
    {
        public bool redKeyObtained;
        public bool greenKeyObtained;
        public bool orangeKeyObtained;
        public bool purpleKeyObtained;

        [Space(10)]

        public UnityEvent redKeyActive;
        public UnityEvent greenKeyActive;
        public UnityEvent orangeKeyActive;
        public UnityEvent purpleKeyActive;

        [Space(10)]

        public UnityEvent redKeyDeactive;
        public UnityEvent greenKeyDeactive;
        public UnityEvent orangeKeyDeactive;
        public UnityEvent purpleKeyDeactive;

        private bool redKeyObtainedPrev;
        private bool greenKeyObtainedPrev;
        private bool orangeKeyObtainedPrev;
        private bool purpleKeyObtainedPrev;

        private void Start()
        {
            //check if keys are changed. if so, check what the current state is. invoke the event depending on the state of the keys.
            if (redKeyObtained) redKeyActive.Invoke();
            else if (!redKeyObtained) redKeyDeactive.Invoke();

            if (greenKeyObtained) greenKeyActive.Invoke();
            else if (!greenKeyObtained) greenKeyDeactive.Invoke();

            if (orangeKeyObtained) orangeKeyActive.Invoke();
            else if (!orangeKeyObtained) orangeKeyDeactive.Invoke();

            if (purpleKeyObtained) purpleKeyActive.Invoke();
            else if (!purpleKeyObtained) purpleKeyDeactive.Invoke();
        }

        private void Update()
        {
            //check if keys are changed. if so, check what the current state is. invoke the event depending on the state of the keys.
            if (redKeyObtained != redKeyObtainedPrev)
            {
                if (redKeyObtained) redKeyActive.Invoke();
                else if (!redKeyObtained) redKeyDeactive.Invoke();
            }
            if (greenKeyObtained != greenKeyObtainedPrev)
            {
                if (greenKeyObtained) greenKeyActive.Invoke();
                else if (!greenKeyObtained) greenKeyDeactive.Invoke();
            }
            if (orangeKeyObtained != orangeKeyObtainedPrev)
            {
                if (orangeKeyObtained) orangeKeyActive.Invoke();
                else if (!orangeKeyObtained) orangeKeyDeactive.Invoke();
            }
            if (purpleKeyObtained != purpleKeyObtainedPrev)
            {
                if (purpleKeyObtained) purpleKeyActive.Invoke();
                else if (!purpleKeyObtained) purpleKeyDeactive.Invoke();
            }

            //set prev bools
            redKeyObtainedPrev = redKeyObtained;
            greenKeyObtainedPrev = greenKeyObtained;
            orangeKeyObtainedPrev = orangeKeyObtained;
            purpleKeyObtainedPrev = purpleKeyObtained;

        }
    }
}
