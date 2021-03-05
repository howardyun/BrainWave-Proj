 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enter : MonoBehaviour
{

    public void Play() {



        SceneManager.LoadScene("RS");

    }

    public void OnClick()
     {
         
         SceneManager.LoadScene("RS");  //加载场景
        Debug.Log("press");
         
     }

    public void OnClick2()
    {

        SceneManager.LoadScene("chooseCity");  //加载场景
        Debug.Log("press");

    }

    public void ExitGame()
     {
        Debug.Log("press");
        
        Application.Quit();
     }



}
