using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Takens
{
    public class CandlePuzzle : MonoBehaviour
    {
        public GameObject[] Candles;
        public GameObject completedLamp;
        public GameObject keyTwo;
        public Material newMat;

        // Update is called once per frame
        void Update()
        {
            if (!Inventory.main.hasCompletedLightPuzzle)
            {
                if (Inventory.main.hasItem(ItemType.tinderBox))
                {
                   for(int x = 0; x < Candles.Length; x++)
                    {
                        if (!Candles[x].GetComponent<CandleLight>().isOn)
                            return;
                    }
                    Inventory.main.hasCompletedLightPuzzle = true;
                    completedLamp.SetActive(true);
                    completedLamp.transform.parent.gameObject.GetComponent<Renderer>().material = newMat;
                    keyTwo.SetActive(true);
                }
            }
        }
    }
}