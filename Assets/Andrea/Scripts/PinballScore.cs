using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Andrea
{


    public class PinballScore : MonoBehaviour
    {
        public int score;
        public Text scoreText;
        void Start()
        {
            Reset();
        }

        void Update()
        {
            scoreText.text = $"Score: {score}";

            if (score >= 3000)
            {
                Inventory.singleton.Set(Item.Ticket);
            }
        }

        public void Reset()
        {
            score = 0;
        }
    }
}