﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_gz : MonoBehaviour
{
    public Canvas c1;
    public Canvas c2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onclick()
    {

        c1.enabled = false;
        c2.enabled = true;
        SetBlock.city = "gz";



    }
}
