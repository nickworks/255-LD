using UnityEngine;

namespace Powers
{
    public class InventoryTut : MonoBehaviour
    {
        public InventoryScript inventory;
        public InventoryUI inventoryUI;

        public GameObject tutOne;
        public GameObject tutTwo;

        // Update is called once per frame
        void Update()
        {
            if(inventory.haveRoomOnePhoto && !inventoryUI.inInventory && inventory.currentlySelectedItem != 2)
            {
                tutOne.SetActive(true);
                tutTwo.SetActive(false);
            }
            else if(inventory.haveRoomOnePhoto && inventoryUI.inInventory && inventory.currentlySelectedItem != 2)
            {
                tutOne.SetActive(false);
                tutTwo.SetActive(true);
            }
            else if(inventory.currentlySelectedItem == 2)
            {
                tutOne.SetActive(false);
                tutTwo.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}

