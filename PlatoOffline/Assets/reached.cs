using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reached : MonoBehaviour
{    static public string passedTime;
    float canGameT;
    float t = 0.0f;
    float timeStamp;

    // Start is called before the first frame update
    void Awake()
    {  
       // canGameT = 900.0f;
        DontDestroyOnLoad(this.gameObject);//this is player health controlelr and dont destroy
    }
    void Start()
    {
        canGameT = 30.0f;//15 min
    }
    // Update is called once per frame
    void Update()
    {
      
        print("countTime" + passedTime);
        canGameT -= Time.deltaTime;
        t = canGameT % 60;//convert to seccond
         if (t <= 0)
         {
            SceneManager.LoadScene(6);//cant game 
            //canGameT = 15.0f;
         }
        passedTime = Math.Round(canGameT).ToString();
        

    }
    void OnApplicationQuit()
    {   //store the time when close any game in this application
        PlayerPrefs.SetFloat("timeStamp",(float)(DateTime.Now-new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)).TotalSeconds);
        PlayerPrefs.Save();
    }
}
