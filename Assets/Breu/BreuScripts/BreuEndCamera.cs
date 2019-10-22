using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreuEndCamera : MonoBehaviour
{

    public Camera cam;
    public float ColorFadeSpeed = .008f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.backgroundColor += new Color(ColorFadeSpeed, ColorFadeSpeed, ColorFadeSpeed);
    }
}
