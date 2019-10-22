using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class MoveCameraToEnd : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject.Find("ForestCamera (1)").transform.position = new Vector3(95, 4, -34);
            
        }
    }
}
