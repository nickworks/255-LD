using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] keys;
    public Image keysImageDisplay;

    public void UpdateKeys(int currentKeys)
    {
        keysImageDisplay.sprite = keys[currentKeys];
    }

    public void UpdateScore()
    {
       
    }
}
