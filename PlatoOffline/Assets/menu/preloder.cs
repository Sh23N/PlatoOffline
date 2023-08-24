using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class preloder : MonoBehaviour
{
    float T=0.1f;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("timeStamp"))
        {
            float now = PlayerPrefs.GetFloat("timeStamp");
            if ((float)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds - now<0.5f)//!!!!change 10
                SceneManager.LoadScene(6);//loade reached 15 min scene
        }
    }

    // Update is called once per frame
    void Update()
    {
        T -= Time.deltaTime;
        t = T % 60;//convert to seccond
        if (t <= 0)
        {
            SceneManager.LoadScene(1);//load menu scene
            
        }
    }
}
