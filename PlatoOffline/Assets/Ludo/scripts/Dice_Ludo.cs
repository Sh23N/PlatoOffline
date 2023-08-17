using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Dice_Ludo : MonoBehaviour
{
    public Sprite[] DiceArray;
    public Button RollButt;
    //public Button RollButton;
    public Image dice;

    static public bool rollClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
     
        if (Turn_Ludo.whoTurn == 1)//system player clicked
        {
            //RollButton.gameObject.SetActive(false);
            if (Turn_Ludo.T % 60 <= 3)
                DiceOnClick();
        }
        if (Turn_Ludo.whoTurn == 2)//system player clicked
        {
           // RollButton.gameObject.SetActive(false);
            if (Turn_Ludo.T % 60 <= 3)
                DiceOnClick();
        }
        if (Turn_Ludo.whoTurn == 4)//system player clicked
        {
           // RollButton.gameObject.SetActive(false);
            if (Turn_Ludo.T % 60 <= 3)
                DiceOnClick();
        }
        else if (Turn_Ludo.whoTurn == 3)//this is human and himSelf mus click
        {
             
           // if (turn.T % 60 <= 4)
               // RollButton.gameObject.SetActive(true);

        }

    }
    int DiceRoll()
    {
        System.Random random = new System.Random();
        int DiceNum = random.Next(1, 7);
        // print("Dice=" + DiceNum);
        return DiceNum;
    }
    public void DiceOnClick()
    {
        
        PlayerI.hitt = false;
        int d = DiceRoll();
        dice.sprite = DiceArray[d-1];
    
        if (Turn_Ludo.whoTurn ==1)
        {
            PlayerI.rand1 = d;
            PlayerI.noMoveForIt1 = true;
        }
        else if (Turn_Ludo.whoTurn == 2)
        {
            PlayerI.rand2 = d;
            PlayerI.noMoveForIt2 = true;
        }
        else if (Turn_Ludo.whoTurn == 3)
        {
            PlayerI.rand3 = d;
            PlayerI.noMoveForIt3 = true;
            RollButt.gameObject.SetActive(false);
            rollClick = true;//******
        }
        else if (Turn_Ludo.whoTurn == 4)
        {
            PlayerI.rand4 = d;
            PlayerI.noMoveForIt4 = true;
        }

        //Turn_Ludo.turnChange();
    }
}
