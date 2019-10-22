using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class MoveCameraBack : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject.Find("ForestCamera (1)").transform.position = new Vector3(47, 4, -46);
            
        }
    }
}
