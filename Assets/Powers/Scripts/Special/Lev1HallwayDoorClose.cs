using System.Collections;
using UnityEngine;

namespace Powers
{
    public class Lev1HallwayDoorClose : MonoBehaviour
    {
        public GameObject player;
        public Animator lightsOneAnimator;
        public Animator lightsTwoAnimator;
        public Animator lightsThreeAnimator;
        public Animator lightsFourAnimator;
        public Animator lightsFiveAnimator;
        public Animator doorTemptingAnimator;

        public GameObject logoReveal;
        public GameObject loadingPrefab;

        private bool hitTrigger = false;
        private bool eventStarted = false;

        private void Update()
        {
            if (hitTrigger)
            {
                if(!eventStarted) StartCoroutine(TransitionEvent());
                eventStarted = true;
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                hitTrigger = true;
            }
        }

        //This is used to close the door to the outside before dramatically breaking every light. Basically, this just times different animations for objects.
        IEnumerator TransitionEvent()
        {
            doorTemptingAnimator.Play("DoorClose", 0, 0f);
            yield return new WaitForSeconds(3);

            if (!lightsOneAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOff")) lightsOneAnimator.Play("LightOff", 0, 0f);
            yield return new WaitForSeconds(1);

            if (!lightsTwoAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOff")) lightsTwoAnimator.Play("LightOff", 0, 0f);
            yield return new WaitForSeconds(1);

            if (!lightsThreeAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOff")) lightsThreeAnimator.Play("LightOff", 0, 0f);
            yield return new WaitForSeconds(1);

            if (!lightsFourAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOff")) lightsFourAnimator.Play("LightOff", 0, 0f);
            yield return new WaitForSeconds(2);

            if (!lightsFiveAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOff")) lightsFiveAnimator.Play("LightOff", 0, 0f);
            yield return new WaitForSeconds(3);

            logoReveal.SetActive(true);
            player.SetActive(false);
            yield return new WaitForSeconds(8.5f);

            GameObject loading = Instantiate(loadingPrefab, new Vector3(0, 100, 0), Quaternion.Euler(0, 0, 0));
            loading.GetComponent<LoadingScript>().sceneName = "Powers_Scene2";

            yield break;
        }
    }
}
