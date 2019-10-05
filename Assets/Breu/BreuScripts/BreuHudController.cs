using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Breu
{
    public class BreuHudController : MonoBehaviour
    {

        public Canvas SideBar;
        public Canvas TutKey;
        public Canvas Key;

        private static BreuHudController current;
        // Start is called before the first frame update
        void Start()
        {
            if (current == null)
            {
                current = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
            SetUIAlpha(SideBar);
            SetUIAlpha(TutKey);
            SetUIAlpha(Key);
        }

        // Update is called once per frame
        void Update()
        {

        }
        void SetUIAlpha(Canvas canvas)
        {
            CanvasGroup CG = canvas.GetComponent<CanvasGroup>();
            CG.alpha = 0f;
        }


        #region Load Levels
        public void loadLevel2()
        {
            SceneManager.LoadScene("BreuScene02", LoadSceneMode.Single);
        }
        public void loadLevel3()
        {
            SceneManager.LoadScene("BreuScene03", LoadSceneMode.Single);
        }
        public void loadLevel4()
        {
            SceneManager.LoadScene("BreuScene04", LoadSceneMode.Single);
        }
        public void loadLevel5()
        {
            SceneManager.LoadScene("BreuScene05", LoadSceneMode.Single);
        }

        #endregion
    }
}
