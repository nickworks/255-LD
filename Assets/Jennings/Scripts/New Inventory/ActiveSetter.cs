using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jennings {

    public class ActiveSetter : MonoBehaviour {
        public GameObject Activator;

        private void OnMouseDown()
        {
            Activator.SetActive(true);
        }
    }
}
