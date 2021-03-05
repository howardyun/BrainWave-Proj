using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay_5s_rs3 : MonoBehaviour
{
    public Animator _am;  //computer  
    public Animator _am1; //player
    float TotalTime = 5;
    public TextMesh t_cd;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());//倒计时函数

    }

    // Update is called once per frame
    void Update()
    {


        if (TotalTime == 0)
        {
            _am.speed = 1;

            _am1.speed = 1;

            TotalTime -= 1;

        }
        else if (TotalTime > 0)
        {

            _am.speed = 0;

            _am1.speed = 0;


        }
    }


    IEnumerator CountDown()
    {
        //倒计时函数
        while (TotalTime >= 0)//倒计时
        {
            Debug.Log(TotalTime);
            t_cd.text = TotalTime.ToString();
            yield return new WaitForSeconds(1);
            TotalTime--;

        }
    }
}
