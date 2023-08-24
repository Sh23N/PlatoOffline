using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class turn : MonoBehaviour
{
   // public GameObject Player;
    bool user1Turn;//system
    bool user2Turn;

    public static float T = 8.0f;// this is period of every turn
    private float t = 0.0f;//this is time
    public static int whoturn;
    public TMP_Text timer;
    // Start is called before the first frame update
    void Start()
    {
        whoturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // if (!Move.hasWiner)
      //  {
            T -= Time.deltaTime;
            t = T % 60;//convert to seccond
                if (t <= 0)
                {

                    turnToggle();
                }
                timer.text = Math.Round(t).ToString();
            
       // }
    }    
 

    public static void turnToggle()
    {   T = 5.0f;
        if(whoturn==0)
            whoturn=1;
        else
            whoturn=0;
    }

}
