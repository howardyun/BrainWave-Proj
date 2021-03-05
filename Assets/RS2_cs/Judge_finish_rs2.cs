using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_finish_rs2 : MonoBehaviour
{
    public Animator _am;
    public Animator _am1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = _am.GetCurrentAnimatorStateInfo(0);      //加载移动动画
        AnimatorStateInfo info1 = _am1.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= 1.0f)
        {
            Debug.Log("You lose");

            
            Application.Quit();
           
        }
        if (info1.normalizedTime >= 1.0f)
        {



            Debug.Log("You win");
            
            Application.Quit();
        }
    }
}
