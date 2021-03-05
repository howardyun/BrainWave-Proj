using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeFinish_rs5 : MonoBehaviour
{


    public Animator _am;   //computer
    public Animator _am1;  //player
    float TotalTime = 5;


    public TextMesh t_c;
    // Start is called before the first frame update
    void Start()
    {
        
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

        if (info.normalizedTime >= 1.0f)
        {
            Debug.Log("You lose");
            SceneManager.LoadScene("chooseCity");

            //Application.Quit();

        }
        if (info1.normalizedTime >= 1.0f)
        {

            SceneManager.LoadScene("chooseCity");


            Debug.Log("You win");

            //Application.Quit();
        }
    }
}
