using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class SetBlock : MonoBehaviour
{
    static public int n;
    static public string city;
    public GameObject []G_obj;



    public int getNum1(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
    {
        
        while (n <= arrNum.Length - 1)
        {
            if (arrNum[n] == tmp) //利用循环判断是否有重复 
            {
                tmp = ra.Next(minValue, maxValue); //重新随机获取。 
                getNum1(arrNum, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。 
            }
            n++;
        }
        return tmp;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        // 把所有的object都变得不可见
        foreach (GameObject a in G_obj)
        {
            a.SetActive(false);
        }
        n = 0;
        
        if (n != 13)
        {
            
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[n];
            int tmp = 0;
            int minValue = 0;
            int maxValue = 12;
            for (int i = 0; i < n; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数 
                arrNum[i] = getNum1(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
                Debug.Log(i + " : " + arrNum[i]);
            }
            activeBlock(arrNum);
        }
        else {


            foreach (GameObject a in G_obj)
            {
                a.SetActive(true);
            }


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  void  activeBlock(int []a)
    {
        for (int i = 0; i < a.Length; i++) {

            G_obj[a[i]].SetActive(true);

        }




    }


    
}
