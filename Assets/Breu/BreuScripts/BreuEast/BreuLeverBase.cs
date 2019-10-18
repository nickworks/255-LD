using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreuLeverBase : MonoBehaviour
{
    public GameObject Pole;
    public GameObject Handle;
    // Start is called before the first frame update
    void Start()
    {
        Pole.SetActive(false);
        Handle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
