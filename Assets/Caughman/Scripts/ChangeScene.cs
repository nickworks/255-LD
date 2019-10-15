using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caughman { 
public class ChangeScene : MonoBehaviour
{

        public bool gotoNextSceneOnClick = false;

        private void OnMouseDown()
        {
        if (gotoNextSceneOnClick) gotoNextScene();
        }


         public void gotoNextScene()
        {
            SceneManager.LoadScene(6);
        }
    }
}
