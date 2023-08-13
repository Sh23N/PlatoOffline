using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Turn_Ludo : MonoBehaviour
{
    public static int whoTurn;
    public static float T = 5.0f;// this is period of every turn
    private float t = 0.0f;//this is time
    public TMP_Text timer;

    public Image Turn1Image;
    public  Image Turn2Image;
    public Image Turn3Image;
    public  Image Turn4Image;

    public Button RollButt;

   
    // Start is called before the first frame update
    void Start()
    {
        whoTurn = 1;// first turn for red
        Turn1Image.enabled = true;
        Turn2Image.enabled = false;
        Turn3Image.enabled = false;
        Turn4Image.enabled = false;
        RollButt.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
       // print("who" + whoTurn);
            T -= Time.deltaTime;
            t = T % 60;//convert to seccond
            if (t <= 0)
            {   
                turnChange();
            }
            timer.text = Math.Round(t).ToString();
        switch (whoTurn)
        {
            case 1:
                Turn1Image.enabled = true;
                Turn2Image.enabled = false;
                Turn3Image.enabled = false;
                Turn4Image.enabled = false;
                RollButt.gameObject.SetActive(false);
                break;
            case 2:
                Turn1Image.enabled = false;
                Turn2Image.enabled = true;
                Turn3Image.enabled = false;
                Turn4Image.enabled = false;
                RollButt.gameObject.SetActive(false);
                break;
            case 3:
                Turn1Image.enabled = false;
                Turn2Image.enabled = false;
                Turn3Image.enabled = true;
                Turn4Image.enabled = false;
                RollButt.gameObject.SetActive(true);
                break;
            case 4:
                Turn1Image.enabled = false;
                Turn2Image.enabled = false;
                Turn3Image.enabled = false;
                Turn4Image.enabled = true;
                RollButt.gameObject.SetActive(false);
                break;
        }
    }
    public static  void turnChange()
    {
        T = 5.0f;
        switch (whoTurn)
        {
            case 1:
                whoTurn = 2;
                break;
            case 2:
                whoTurn = 3;
                break;
            case 3:
                whoTurn = 4;
                break;
            case 4:
                whoTurn = 1;
                break;
        }
    }
   
}
