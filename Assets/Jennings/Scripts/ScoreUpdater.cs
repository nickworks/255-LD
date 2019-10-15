using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        score = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = score.ToString();
        score--;

        if(score <= 0)
        {
            print("Ran out of time! Try again!");
            score = 0;
        }
    }
}
