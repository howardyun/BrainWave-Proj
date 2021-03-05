using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCollide_RS5 : MonoBehaviour
{


    public GameObject a;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //此函数用于检测物体是否有碰撞


        if (other.gameObject.name == "cube1")
        {


            Debug.Log("Collide");

        }

    }



}
