using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay_5s_rs1 : MonoBehaviour
{
    public Animator _am;  //computer  
    public Animator _am1; //player
    float TotalTime = 5;
    public TextMesh t_cd;
    public TextMesh t_ct;
    static public int j=0;
    static public float time;
    float st;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());//倒计时函数

    }

    // Update is called once per frame
    void Update()
    {

         st += Time.deltaTime;
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
        else {
            if (j == 0)
            {
                Debug.Log("" + j);
                t_ct.text = "计时： " + Math.Round((st - 5), 2);

            }
            else if (j == 1)
            {

                Debug.Log("" + j);

                time = st - 5;
                t_ct.text = "Finish";
                j++;
            }
            else if (j == 2) {


                t_ct.text ="Time is :"+ Math.Round((time), 2);

            }
            


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
