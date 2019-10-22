using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class MoveCameraWest : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject.Find("ForestCamera (1)").transform.position = new Vector3(26, 4, -39);
            
        }
    }
}
