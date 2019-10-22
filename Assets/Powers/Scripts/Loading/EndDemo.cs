using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Powers
{
    public class EndDemo : MonoBehaviour
    {
        public GameObject demoEndText;

        private bool inTrigger = false;
        private bool eventStarted = false;

        // Update is called once per frame
        void Update()
        {
            if (inTrigger && !eventStarted)
            {
                StartCoroutine(DemoEnded());
                eventStarted = true;
            }
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.tag == "Player") inTrigger = true;
        }

        IEnumerator DemoEnded()
        {
            demoEndText.SetActive(true);
            yield return new WaitForSeconds(3);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
            Cursor.lockState = CursorLockMode.None;

            //wait until scene is loaded
            while (!asyncLoad.isDone) yield return null;
        }
    }
}

