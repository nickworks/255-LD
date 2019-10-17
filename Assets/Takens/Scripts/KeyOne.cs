using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takens
{
    public class KeyOne : MonoBehaviour
    {
        void OnMouseDown()
        {
            Inventory.main.hasFirstKey = true;
            Destroy(gameObject);
        }
    }
}
