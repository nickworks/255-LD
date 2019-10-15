using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
