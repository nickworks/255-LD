﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public GameObject objectFollowed;

    // Update is called once per frame
    void Update()
    {
        transform.position = objectFollowed.transform.position;
    }
}
