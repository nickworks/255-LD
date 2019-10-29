using System.Collections;
using UnityEngine;

namespace Powers
{
    public class Lev1HallwayTeleport : MonoBehaviour
    {
        public GameObject player;
        public Animator doorTransitionAnimator;
        public Animator lightsOneAnimator;
        public Animator lightsTwoAnimator;
        public Animator lightsThreeAnimator;
        public Animator lightsFourAnimator;
        public Animator lightsFiveAnimator;
        public Animator doorTemptingAnimator;

        private bool hitTrigger = false;
        private bool eventStarted = false;

        private void Update()
        {
            if (hitTrigger)
            {
                if (!eventStarted) StartCoroutine(TransitionEvent());
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

        //This is used to close the behind the player, teleport the player, and then one by one activate the lights. Basically, this just times different animations for objects.
        IEnumerator TransitionEvent()
        {
            if (!doorTransitionAnimator.GetCurrentAnimatorStateInfo(0).IsName("DoorClose")) doorTransitionAnimator.Play("DoorClose", 0, 0f);
            yield return new WaitForSeconds(1.8f);
            
            //teleport player to the actual hallway to ensure global illumination from the bright tutorial doesn't interfere.
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.1f, player.transform.position.z + 30);
            yield return new WaitForSeconds(1);

            if (!lightsOneAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOn")) lightsOneAnimator.Play("LightOn", 0, 0f);
            yield return new WaitForSeconds(0.5f);

            if (!lightsTwoAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOn")) lightsTwoAnimator.Play("LightOn", 0, 0f);
            yield return new WaitForSeconds(0.5f);

            if (!lightsThreeAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOn")) lightsThreeAnimator.Play("LightOn", 0, 0f);
            yield return new WaitForSeconds(0.5f);

            if (!lightsFourAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOn")) lightsFourAnimator.Play("LightOn", 0, 0f);
            yield return new WaitForSeconds(0.5f);

            if (!lightsFiveAnimator.GetCurrentAnimatorStateInfo(0).IsName("LightOn")) lightsFiveAnimator.Play("LightOn", 0, 0f);
            yield return new WaitForSeconds(1);

            if (!doorTemptingAnimator.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) doorTemptingAnimator.Play("DoorOpen", 0, 0f);
            yield return new WaitForSeconds(1);

            Destroy(gameObject);

            yield break;
        }
    }
}