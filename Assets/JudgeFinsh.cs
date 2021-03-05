using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeFinsh : MonoBehaviour
{
    public Animator _am;   //computer
    public Animator _am1;  //player
    public TextMesh t_c;
    public Canvas c1;
    public Text rezult;
    public Text time;
    public int j=1;
    void Start()
    {
        c1.enabled = false;
        
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
        AnimatorStateInfo info = _am.GetCurrentAnimatorStateInfo(0);      //加载移动动画
        AnimatorStateInfo info1 = _am1.GetCurrentAnimatorStateInfo(0);
        if (j == 1) {

            if (info.normalizedTime >= 1.0f)
            {
                j = 0;
                rezult.text = "You Lose";
                Debug.Log("You lose");
                Delay_5s_rs1.j = 1;

                c1.enabled = true;
            }
            if (info1.normalizedTime >= 1.0f)
            {
                j = 0;
                c1.enabled = true;
                Delay_5s_rs1.j = 1;
                rezult.text = "You Win";
                Debug.Log("You win");
            }

        }



     


        if (Input.GetKeyDown(KeyCode.S))
        {

            _am1.speed -= 1;

            Debug.Log("s");

        }



    }
}
