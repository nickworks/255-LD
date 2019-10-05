using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreuTextController : MonoBehaviour
{
    public Canvas Text1;
    public Canvas Text2;
    public Canvas Text3;
    public Canvas Text4;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetTextAlpha(Text1);
        SetTextAlpha(Text2);
        SetTextAlpha(Text3);
        SetTextAlpha(Text4);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 801)//text fade in
        {
            timer += 1 + Time.deltaTime;
            if (timer >= 60 && timer <= 200)
            {
                MakeTextVisable(Text1);
            }
            if (timer >= 250 && timer <= 400)
            {
                MakeTextVisable(Text2);
            }
            if (timer >= 450 && timer <= 600)
            {
                MakeTextVisable(Text3);
            }
            if (timer >= 650 && timer <= 800)
            {
                MakeTextVisable(Text4);
            }
        }
    }

    void SetTextAlpha(Canvas text)
    {
        if (text != null)
        {
            CanvasGroup canvasgroup = text.GetComponent<CanvasGroup>();
            canvasgroup.alpha = 0;
        }

    }

    void MakeTextVisable(Canvas text)
    {
        if (text != null)
        {
                CanvasGroup canvasgroup = text.GetComponent<CanvasGroup>();
                canvasgroup.alpha += 0.01f;
        }
    }
}
