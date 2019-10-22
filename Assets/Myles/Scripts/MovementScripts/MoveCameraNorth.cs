using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public class MoveCameraNorth : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject.Find("ForestCamera (1)").transform.position = new Vector3(46, 4, -34);
            
        }
    }
}
