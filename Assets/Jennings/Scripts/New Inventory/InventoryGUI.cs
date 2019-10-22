using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jennings { 
public class InventoryGUI : MonoBehaviour
{

    public Text textHint;

    public Image imgRedKey;
    public Image imgBlueKey;
    public Image imgGreenKey;
    public Image imgOrangeKey;

        // Start is called before the first frame update
        void Start()
    {

        }

    // Update is called once per frame
    void Update()
    {
            if (Inventory.main.itemBeingUsed == Item.None)
            {
                textHint.text = "";
            } else
            {
                textHint.text = $"Insert {Inventory.main.itemBeingUsed} in lock and click to utilize.";
            }


        imgRedKey.gameObject.SetActive(Inventory.main.HasItem(Item.RedKey));
        imgBlueKey.gameObject.SetActive(Inventory.main.HasItem(Item.BlueKey));
        imgGreenKey.gameObject.SetActive(Inventory.main.HasItem(Item.GreenKey));
        imgOrangeKey.gameObject.SetActive(Inventory.main.HasItem(Item.OrangeKey));
        }
    }
}