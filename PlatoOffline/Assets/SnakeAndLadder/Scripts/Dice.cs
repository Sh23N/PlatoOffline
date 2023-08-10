using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite[] DiceArray;

    public Button RollButton;
    public Image dice;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (turn.whoturn == 0 )//system player clicked
        {
            RollButton.gameObject.SetActive(false);
            if (turn.T % 60 <= 3)
                DiceOnClick();
            // turn.T = 5.0f;
            //ChngeSide();
            // turn.turnToggle();
        }
        else if (turn.whoturn == 1 )
        {
            if (turn.T % 60 <= 4)
                RollButton.gameObject.SetActive(true);
           
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
        
       // DiceClick0 = true;
        int d = DiceRoll();
        dice.sprite = DiceArray[d-1];

        if (turn.whoturn == 0)
        {
            Move.rand0 = d;
            Move.noMoveForIt0 = true;
          //  print(  Move.noMoveForIt0);
        }
        else if (turn.whoturn == 1)
        {
            Move.rand1 = d;
            Move.noMoveForIt1 = true;
        }
        turn.turnToggle();
    }


}
