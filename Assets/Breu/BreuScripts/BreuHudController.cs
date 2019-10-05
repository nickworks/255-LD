using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Breu
{
    public class BreuHudController : MonoBehaviour
    {

        public Canvas UISideBar;
        public Canvas UITutKey;
        public Canvas UIKey;


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
            MakeInvisable(UISideBar);
            MakeInvisable(UITutKey);
            MakeInvisable(UIKey);
        }

        // Update is called once per frame
        void Update()
        {
            if (BreuInventory.main.tutKey == true)
            {
                MakeVisable(UISideBar);
                MakeVisable(UITutKey);
            }
            if (BreuInventory.main.tutKey == false)
            {
                MakeInvisable(UITutKey);
            }

        }
        void MakeInvisable(Canvas canvas)
        {
            CanvasGroup CG = canvas.GetComponent<CanvasGroup>();
            CG.alpha = 0f;
        }

        void MakeVisable(Canvas canvas)
        {
            CanvasGroup CG = canvas.GetComponent<CanvasGroup>();
            CG.alpha = 1f;
        }


        
    }
}
