using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool flag;
    void Start()
    {
        DontDestroyOnLoad(this);//这个作用是场景切换时，一下代码不撤销

        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag = false;

        }
        else
            flag = true;



    }
    


}
