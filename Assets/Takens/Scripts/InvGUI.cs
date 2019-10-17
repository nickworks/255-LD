using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens {
    public class InvGUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Inventory.main.Set(ItemType.empty, false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}