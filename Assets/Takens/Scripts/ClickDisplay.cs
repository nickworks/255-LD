using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens {
    public class ClickDisplay : MonoBehaviour
    {
        public string message;
        private InvGUI i;
        public void Start()
        {
            i = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InvGUI>();
        }

        // Update is called once per frame
        void OnMouseDown()
        {
            i.displayMessage(message);
        }
    }
}