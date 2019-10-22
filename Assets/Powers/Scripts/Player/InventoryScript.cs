using UnityEngine;

namespace Powers
{
    public class InventoryScript : MonoBehaviour
    {
        public bool haveRoomOneCode;
        public bool haveRoomOnePhoto;
        public bool haveRoomOneKey;
        public bool haveRoomTwoCode;
        public bool haveRoomTwoPhoto;
        public bool haveRoomTwoKey;

        [Space(10)]

        public GameObject codeRoomOneUI;
        public GameObject photoRoomOneUI;
        public GameObject keyRoomOneUI;
        public GameObject codeRoomTwoUI;
        public GameObject photoRoomTwoUI;
        public GameObject keyRoomTwoUI;

        private void Update()
        {
            //set object ui's depending on what objects are held
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
        }
    }
}

