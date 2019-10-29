using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuButton2 : MonoBehaviour
    {

        void OnMouseUp()
        {
            if (BreuWorldControllerr.main.pressedButton1 == true)
            {
                BreuWorldControllerr.main.pressedButton2 = true;
            }
        }
    }
}