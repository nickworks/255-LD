using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jennings {

    public class NotActive : MonoBehaviour {
        public GameObject Deactivate;

        private void OnMouseDown()
        {
            Deactivate.SetActive(false);

        }
    }
}
