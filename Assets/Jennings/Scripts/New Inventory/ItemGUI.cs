using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jennings { 
public class ItemGUI : MonoBehaviour
{

    public Item item;
    private Image image;

    void Start()
    {
            image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
            bool hasItem = Inventory.main.HasItem(item);
            
                image.enabled = hasItem;
            
    }

        private void OnMouseDown()
        {
            print("CLICKED");
        }
        public void HandleClick()
        {
            Inventory.main.itemBeingUsed = item;
        }
}
}
