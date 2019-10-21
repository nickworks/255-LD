using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Takens {

    public class InvGUI : MonoBehaviour
    {
        private bool isDisplaying = false;
        private float speed = 3f;
        public Text displayText;
        public Text itemDesc;

        // Start is called before the first frame update
        void Start()
        {
            Inventory.main.Set(ItemType.empty, false);
        }

        public void displayMessage(string msg)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (!isDisplaying)
                    StartCoroutine(Display(msg));
            }
        }

        public void Update()
        {
            switch (Inventory.main.selectedItem)
            {
                case (ItemType.empty):
                    itemDesc.text = "";
                        break;
                case (ItemType.keyOne):
                    itemDesc.text = "Use door key on...";
                        break;
                case (ItemType.keyTwo):
                    itemDesc.text = "Use door key on...";
                    break;
                case (ItemType.tinderBox):
                    itemDesc.text = "Use tinderbox on...";
                    break;
                case (ItemType.hammer):
                    itemDesc.text = "Use hammer on...";
                    break;
                case (ItemType.nightStandKey):
                    itemDesc.text = "Use nightstand key on...";
                    break;
                case (ItemType.candleStick):
                    itemDesc.text = "Use candlestick key on...";
                    break;
                case (ItemType.codeBreaker):
                    itemDesc.text = "Use code breaker on...";
                    break;
                default:
                    break;
            }
        }

        public IEnumerator Display(string msg)
        {
            
            isDisplaying = true;
            displayText.text = msg;
            displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, 0);
            while(displayText.color.a < 1f)
            {
                displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, displayText.color.a + (Time.deltaTime * speed));
                yield return null;
            }
            yield return new WaitForSeconds(.5f);

            displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, 1f);
            while (displayText.color.a > 0f)
            {
                displayText.color = new Color(displayText.color.r, displayText.color.g, displayText.color.b, displayText.color.a - (Time.deltaTime * speed));
                yield return null;
            }
            isDisplaying = false;
        }
    }
}