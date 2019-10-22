using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breu
{
    public class BreuButton4 : MonoBehaviour
    {

        void OnMouseUp()
        {
            if (BreuWorldControllerr.main.pressedButton3 == true)
            {
                BreuWorldControllerr.main.pressedButton4 = true;
            }
        }
    }
}