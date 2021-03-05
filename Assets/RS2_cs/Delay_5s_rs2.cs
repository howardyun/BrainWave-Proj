using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//该类用于为一开始赛车比赛进行延时5s
public class Delay_5s_rs2 : MonoBehaviour
{



    public Animator _am;         
    public Animator _am1;
    float TotalTime = 5;
    public TextMesh t_cd;
    public TextMesh t_ct;
    float st;
    void Start()
    {

        StartCoroutine(CountDown());//倒计时函数
        

    }

    public void SetAnimationSpeed(float speed)
    {
#if UNITY_ANDROID
        _am1.speed = speed;
#endif
    }

    // Update is called once per frame
    void Update()
    {

        st += Time.deltaTime;
        


        if (TotalTime == 0)
        {
            _am.speed = 1;

            _am1.speed = 1;



            t_cd.gameObject.SetActive(false);

            TotalTime -= 1;

        }
        else if (TotalTime > 0)
        {

            _am.speed = 0;

            _am1.speed = 0;


        }
        else
        {

            t_ct.text = "计时： " + Math.Round((st - 5), 2);



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
