using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breu {
    public class BreuTextController : MonoBehaviour
    {
        public Canvas Text1;
        public Canvas Text2;
        public Canvas Text3;
        public Canvas Text4;
        public Canvas PostKeyButton;
        public Canvas PostDoorButton;
        public Button UIButton;

        private float timer = 0;
        // Start is called before the first frame update
        void Start()
        {
            if (Text1 != null) SetTextAlpha(Text1);
            if (Text2 != null) SetTextAlpha(Text2);
            if (Text3 != null) SetTextAlpha(Text3);
            if (Text4 != null) SetTextAlpha(Text4);
            if (PostKeyButton != null) SetTextAlpha(PostKeyButton);
            if (PostDoorButton != null) SetTextAlpha(PostDoorButton);
            if (UIButton != null) UIButton.interactable = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (timer < 801)//text fade in
            {
                timer += 1 + Time.deltaTime;
                if (timer >= 60 && Text1 != null)
                {
                    MakeTextVisable(Text1);
                }
                if (timer >= 250 && Text2 != null)
                {
                    MakeTextVisable(Text2);
                }
                if (timer >= 450 && Text3 != null)
                {
                    MakeTextVisable(Text3);
                }
                if (timer >= 650 && Text4 != null)
                {
                    MakeTextVisable(Text4);
                    UIButton.interactable = true;
                }
            }
            if (BreuInventory.main.tutKey == true && PostKeyButton != null)
            {
                MakeTextVisable(PostKeyButton);
                UIButton.interactable = true;
            }
            if(BreuInventory.main.tutDoor == true &&  PostDoorButton != null)
            {
                MakeTextVisable(PostDoorButton);
                UIButton.interactable = true;
            }
        }

        void SetTextAlpha(Canvas text)
        {

                CanvasGroup canvasgroup = text.GetComponent<CanvasGroup>();
                canvasgroup.alpha = 0;
        }

        void MakeTextVisable(Canvas text)
        {
            CanvasGroup canvasgroup = text.GetComponent<CanvasGroup>();
            canvasgroup.alpha += 0.01f;                    
        }
    }
}