using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Caughman
{

    public class Door2 : MonoBehaviour
    {
        private void OnMouseDown()
        { 
                GetComponent<ChangeScene>().gotoNextScene();           
        }
    }
}
