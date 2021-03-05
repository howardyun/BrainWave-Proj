using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialCanvas : MonoBehaviour
{


    public Canvas[] canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas[0].enabled = true;

        for (int i=1;i<6 ;i++) {

            canvas[i].enabled = false; 


        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
