using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JudgeCollide : MonoBehaviour
{


    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //此函数用于检测物体是否有碰撞


        if (other.gameObject.name=="block1") {


            
            Debug.Log("Collide cube1");

        }

        if (other.gameObject.name == "cube2")
        {


            Debug.Log("Collide cube2");

        }





    }






}
