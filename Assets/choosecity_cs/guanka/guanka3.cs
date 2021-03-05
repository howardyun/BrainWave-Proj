using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guanka3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick()
    {

        SetBlock.n = 13;
        string tmp_s = SetBlock.city;
        if (tmp_s.Equals("bj"))
        {
            Debug.Log("enterBJ");
            SceneManager.LoadScene("RS1");


        }
        else if (tmp_s.Equals("sh"))
        {
            Debug.Log("enterSH");
            SceneManager.LoadScene("RS2");





        }
        else if (tmp_s.Equals("cd"))
        {

            Debug.Log("enterCD");
            SceneManager.LoadScene("RS3");



        }
        else if (tmp_s.Equals("gz"))
        {
            Debug.Log("enterGZ");
            SceneManager.LoadScene("RS4");




        }
        else if (tmp_s.Equals("tj"))
        {

            Debug.Log("enterTJ");
            SceneManager.LoadScene("RS5");


        }

    }
}
