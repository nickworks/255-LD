using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Powers
{
    public class LoadingScript : MonoBehaviour
    {
        [Tooltip("The scene to load.")]
        public string sceneName;

        public Material fadeTransitionMaterial;
        private float fadeAlpha = 1f;
        private float fadeVelocity = 0f;

        // Update is called once per frame
        void Start()
        {
            //ensure loading screen isn't destroyed once level is loaded so a smooth transition can be done.
            DontDestroyOnLoad(gameObject);

            StartCoroutine(LevelTransition());
        }

        IEnumerator LevelTransition()
        {
            //fade loading screen in
            if (fadeAlpha != 0f)
            {
                fadeAlpha = Mathf.SmoothDamp(fadeAlpha, 0f, ref fadeVelocity, 1f);
                fadeTransitionMaterial.SetColor("_Color", new Color(0, 0, 0, fadeAlpha));
                yield return null;
            }

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            //wait until scene is loaded
            while (!asyncLoad.isDone) yield return null;

            //fade loading screen out
            if (fadeAlpha != 1f)
            {
                fadeAlpha = Mathf.SmoothDamp(fadeAlpha, 1f, ref fadeVelocity, 1f);
                fadeTransitionMaterial.SetColor("_Color", new Color(0, 0, 0, fadeAlpha));
                yield return null;
            }

            //destroy loading screen so it doesn't interfere with gameplay or scene.
            Destroy(gameObject);

            yield break;
        }
    }
}

