using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuButton3 : MonoBehaviour
    {

        void OnMouseUp()
        {
            if (BreuWorldControllerr.main.pressedButton2 == true)
            {
                BreuWorldControllerr.main.pressedButton3 = true;
            }
        }
    }
}