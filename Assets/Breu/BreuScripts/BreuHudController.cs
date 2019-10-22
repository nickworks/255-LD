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
        public Canvas UIKey;//found in north, bottom drawer
        public Canvas UIHandle;//found in north, top drawer
        public Canvas UIPole;//found in south, complete button/timing puzzle
        public Canvas UILever;//found by combineing pole and handle
        public Canvas UIOil;//found in east
        public Canvas UIClock;//found in north, middle drawer
        public Canvas UICutter;//found in west
        public Canvas UIMallet;//found in south


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
            #region Tutorial
            //tutorial jey and UI spawn controls
            if (BreuInventory.main.tutKey == true)
            {
                MakeVisable(UISideBar);
                MakeVisable(UITutKey);
            }
            if (BreuInventory.main.tutKey == false)
            {
                MakeInvisable(UITutKey);
            }
            #endregion
            #region  item visual controls
            setVisability(UIHandle, BreuInventory.main.hasHandle);
            setVisability(UIPole, BreuInventory.main.hasPole);
            setVisability(UILever, BreuInventory.main.hasLever);
            setVisability(UIOil, BreuInventory.main.hasOil);
            setVisability(UIClock, BreuInventory.main.hasClock);
            setVisability(UICutter, BreuInventory.main.hasCutter);
            setVisability(UIMallet, BreuInventory.main.hasMallet);
            setVisability(UIKey, BreuInventory.main.hasKey);
#endregion

        }

        void setVisability (Canvas canvas, bool hasItem)
        {
            if (hasItem == false)
            {
                MakeInvisable(canvas);
            }
            if (hasItem == true)
            {
                MakeVisable(canvas);
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
