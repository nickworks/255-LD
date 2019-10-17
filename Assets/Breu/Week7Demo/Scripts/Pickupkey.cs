using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreuWeek7
{
    public class Pickupkey : MonoBehaviour
    {
        void OnMouseDown()
        {
            Inventory.main.hasKey = true;
            print("Key get!");

            Destroy(gameObject);
        }
    }
}