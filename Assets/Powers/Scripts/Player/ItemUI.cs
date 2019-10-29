using UnityEngine;

namespace Powers
{
    public class ItemUI : MonoBehaviour
    {
        public GameObject itemUI;

        void OnMouseEnter()
        {
            itemUI.SetActive(true);
        }

        void OnSelect()
        {
            itemUI.SetActive(false);
        }
    }
}
