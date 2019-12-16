using UnityEngine;

namespace Powers
{
    public class InventoryScript : MonoBehaviour
    {
        public bool active = false;

        [Space(10)]

        public bool haveRoomOneCode;
        public bool haveRoomOnePhoto;
        public bool haveRoomOneKey;
        public bool haveRoomTwoCode;
        public bool haveRoomTwoPhoto;
        public bool haveRoomTwoKey;
        public bool haveRoomThreeCode;
        public bool haveRoomThreePhoto;
        public bool haveRoomThreeKey;

        [HideInInspector]
        public int currentlySelectedItem = 0;
        //this determines the selected item. 0 means no item selected

        [Space(10)]

        public GameObject codeRoomOneUI;
        public GameObject photoRoomOneUI;
        public GameObject keyRoomOneUI;
        public GameObject codeRoomTwoUI;
        public GameObject photoRoomTwoUI;
        public GameObject keyRoomTwoUI;
        public GameObject codeRoomThreeUI;
        public GameObject photoRoomThreeUI;
        public GameObject keyRoomThreeUI;

        [Space(10)]

        public GameObject cursor;
        public GameObject cantUseObjectNotify;
        public GameObject codeRoomOneSelected;
        public GameObject photoRoomOneSelected;
        public GameObject keyRoomOneSelected;
        public GameObject codeRoomTwoSelected;
        public GameObject photoRoomTwoSelected;
        public GameObject keyRoomTwoSelected;
        public GameObject codeRoomThreeSelected;
        public GameObject photoRoomThreeSelected;
        public GameObject keyRoomThreeSelected;

        private void Update()
        {
            if(active)
            {
                //set object ui's depending on what objects are available
                if (haveRoomOneCode) codeRoomOneUI.SetActive(true);
                else codeRoomOneUI.SetActive(false);

                if (haveRoomOnePhoto) photoRoomOneUI.SetActive(true);
                else photoRoomOneUI.SetActive(false);

                if (haveRoomOneKey) keyRoomOneUI.SetActive(true);
                else keyRoomOneUI.SetActive(false);

                if (haveRoomTwoCode) codeRoomTwoUI.SetActive(true);
                else codeRoomTwoUI.SetActive(false);

                if (haveRoomTwoPhoto) photoRoomTwoUI.SetActive(true);
                else photoRoomTwoUI.SetActive(false);

                if (haveRoomTwoKey) keyRoomTwoUI.SetActive(true);
                else keyRoomTwoUI.SetActive(false);

                if (haveRoomThreeCode) codeRoomThreeUI.SetActive(true);
                else codeRoomThreeUI.SetActive(false);

                if (haveRoomThreePhoto) photoRoomThreeUI.SetActive(true);
                else photoRoomThreeUI.SetActive(false);

                if (haveRoomThreeKey) keyRoomThreeUI.SetActive(true);
                else keyRoomThreeUI.SetActive(false);

                //set selected indicator depending on what object is currently selected

                if (currentlySelectedItem == 0) cursor.SetActive(true);
                else cursor.SetActive(false);

                if (currentlySelectedItem == 1) codeRoomOneSelected.SetActive(true);
                else codeRoomOneSelected.SetActive(false);

                if (currentlySelectedItem == 2) photoRoomOneSelected.SetActive(true);
                else photoRoomOneSelected.SetActive(false);

                if (currentlySelectedItem == 3) keyRoomOneSelected.SetActive(true);
                else keyRoomOneSelected.SetActive(false);

                if (currentlySelectedItem == 4) codeRoomTwoSelected.SetActive(true);
                else codeRoomTwoSelected.SetActive(false);

                if (currentlySelectedItem == 5) photoRoomTwoSelected.SetActive(true);
                else photoRoomTwoSelected.SetActive(false);

                if (currentlySelectedItem == 6) keyRoomTwoSelected.SetActive(true);
                else keyRoomTwoSelected.SetActive(false);

                if (currentlySelectedItem == 7) codeRoomThreeSelected.SetActive(true);
                else codeRoomThreeSelected.SetActive(false);

                if (currentlySelectedItem == 8) photoRoomThreeSelected.SetActive(true);
                else photoRoomThreeSelected.SetActive(false);

                if (currentlySelectedItem == 9) keyRoomThreeSelected.SetActive(true);
                else keyRoomThreeSelected.SetActive(false);
            }
            
        }

        public void SetSelectedItem(int selectedItem)
        {
            currentlySelectedItem = selectedItem;
        }
    }
}

