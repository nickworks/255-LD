using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class MoveCameraSouth : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject.Find("ForestCamera (1)").transform.position = new Vector3(11, 4, -48);
            
        }
    }
}
