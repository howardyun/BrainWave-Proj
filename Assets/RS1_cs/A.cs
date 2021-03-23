using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    
    public TextMesh brainPower;
    public Animator _am1;  //player
    void Start()
    {
        // AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        //jo.Call("initView");
        AndroidJavaObject jo = new AndroidJavaObject("com.unity3d.player.Mytestclass");
       int i= jo.Call<int>("getT");
        Debug.Log("ZZZZZZ"+i);
    }
    
    public void SensorInfo(string msg)
    {
        Debug.Log("SensorInfo called");
        Debug.Log("get sensor info msg: " + msg);
        string[] items = msg.Split('|');
        if (items != null)
        {
            int code = 0;
            Time.timeScale = 1;
            if (int.TryParse(items[0], out code))
            {
                if (code == 502)   //接收的标志
                {
                    int attention = -1;
                    if (int.TryParse(items[1], out attention))
                    {
                        Debug.Log("attention : " + attention);
                        int speed = 1;
                        brainPower.text = "注意力：" + attention.ToString();
                        if (attention > 0 && attention <= 20)
                        {
                            speed = 0;
                            _am1.speed = speed;
                        }
                        else if (attention <= 40)
                        {
                            speed = 1;
                            _am1.speed = speed;
                        }
                        else if (attention <= 60)
                        {
                            speed = 3;
                            _am1.speed = speed;
                        }
                        else if (attention <= 80)
                        {
                            speed = 5;
                            _am1.speed = speed;
                        }
                        else if (attention <= 100)
                        {
                            speed = 10;
                            _am1.speed = speed;
                        }

                      
                    }
                }
                else {
                    _am1.speed = 0;
                    brainPower.text = "没有接收到脑电波1";



                }
            }
            else
            {
                _am1.speed = 0;

                brainPower.text = "没有接收到脑电波2";



            }
        }
        else {

            Time.timeScale = 0;
            _am1.speed = 0;
            brainPower.text = "No bluetooth device connect";
            Debug.Log("No bluetooth device connect");
        }




    }
    public void kuikui(string s) {


        Debug.Log(s);


    }

}
