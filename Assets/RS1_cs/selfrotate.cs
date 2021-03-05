using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfrotate : MonoBehaviour
{
    int Speed = 1;
    public float zhenFu = 10f;//振幅
    public float HZ = 1f;//频率
    Vector3 trans_tmp;
    Vector3 trans_tmp1;
    void Awake() {



        trans_tmp1 = this.transform.position;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        trans_tmp = trans_tmp1;
        trans_tmp.y= Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans_tmp1.y;
        this.transform.position = trans_tmp;


        this.transform.Rotate(Vector3.up * Speed);

    }
}
