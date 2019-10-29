using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{
    public class PinballPointValue : MonoBehaviour
    {
        public int bumperValue = 50;
        public GameObject scoreManager;
        PinballScore pinballScore;
        //public GameObject scorePanel;
        public Text scoreText;

        void Start()
        {
            pinballScore = scoreManager.GetComponent<PinballScore>();
            //scoreText = scorePanel.transform.Find("Score").GetChild(0).GetComponent<Text>();
        }
        void OnCollisionEnter()
        {
            pinballScore.score += bumperValue;
            //scoreText.text = $"Score: {pinballScore.score}";
        }

    }
}