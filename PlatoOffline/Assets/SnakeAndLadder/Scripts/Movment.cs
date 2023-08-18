using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Movment : MonoBehaviour
{
    public static  Transform[] wayPoints = new Transform[100] ;
    public  Transform[] way_Points; 

    public static int rand0;
    public static int rand1;

    public static int currentIndex0 = 0;
    public static int currentIndex1 = 0;

    public static int lastIndex0 = 0;
    public static int lastIndex1 = 0;

    public static bool noMoveForIt1;
    public static bool noMoveForIt0;

    int stay = 0;

    public static bool hasWiner;//

    public GameObject WinCanvas;
    public TMP_Text WinerText;

    public GameObject player0;
    public GameObject player1;

    public static GameObject Player0;
    public static GameObject Player1;

    public static bool alive0;
    public static bool alive1;
    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        alive0 = false;
        alive1 = false;
        currentIndex0 = 0;
        currentIndex1 = 0;
        lastIndex0 = 0;
        lastIndex1 = 0;
        hasWiner = false;
        for (int i = 0; i < way_Points.Length; i++)
        {
            wayPoints[i] = way_Points[i];
        }
        Player0 = player0;
        Player1 = player1;
        lastIndex0 = 0;
        lastIndex1 = 0;
        currentIndex0 = 0;
        currentIndex1 = 0;        
        WinCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void moveTo()
    {
        if (turn.whoturn == 0)
        {   
            lastIndex0 = currentIndex0;
            if (currentIndex0 + rand0 < 100 && alive0)
            {
                currentIndex0 += rand0;
                Player0.transform.position = wayPoints[currentIndex0].position;
            }
            else if (rand0 == 6)
            {
                alive0 = true;
                Player0.transform.position = wayPoints[0].position;
            }
            turn.turnToggle();
        }
        else if (turn.whoturn == 1)
        {
           
            lastIndex1 = currentIndex1;
            if (currentIndex1 + rand1 < 100 && alive1)
            {
                currentIndex1 += rand1;
                Player1.transform.position = wayPoints[currentIndex1].position;
            }
            else if (rand1 == 6)
            {
                alive1 = true;
                Player1.transform.position = wayPoints[0].position;
            }
                turn.turnToggle();
        }
    }
    void OnCollisionStay2D(Collision2D a)
    {
        if (a.gameObject.tag == "snake" && !hasWiner)
        {
            if (gameObject.name == "Player0")
            {
                currentIndex0 = AsignTail(a.gameObject.name);
                Player0.transform.position = wayPoints[currentIndex0].position;
            }
            else if (gameObject.name == "Player1")
            {
                currentIndex1 = AsignTail(a.gameObject.name);
                Player1.transform.position = wayPoints[currentIndex1].position;
            }


        }
        else if (a.gameObject.tag == "ladder" && !hasWiner)
        {
           // AsignLadder(a.gameObject.name);
            if (gameObject.name == "Player0")
            {
                currentIndex0 = AsignLadder(a.gameObject.name);
                Player0.transform.position = wayPoints[currentIndex0].position;
            }
            else if (gameObject.name == "Player1")
            {
                currentIndex1 = AsignLadder(a.gameObject.name);
                Player1.transform.position = wayPoints[currentIndex1].position;
            }
        }
        else if (a.gameObject.tag == "WinSq" && !hasWiner)
        {
            print("winer is" + gameObject.name);
            hasWiner = true;
            WinCanvas.SetActive(true);
            if (gameObject.name == "Player0")
                WinerText.text = "System";
            else if (gameObject.name == "Player1")
                WinerText.text = "You";
        }
        
    }
    int AsignTail(string SnakeName)
    {
        int wayPointIndex = 0;
        switch (SnakeName)
        {
            case "Snake1":
                wayPointIndex = 41;
                break;
            case "Snake2":
                wayPointIndex = 17;
                break;
            case "Snake3":
                wayPointIndex = 25;
                break;
            case "Snake4":
                wayPointIndex = 83;
                break;
            case "Snake5":
                wayPointIndex = 14;
                break;
            case "Snake6":
                wayPointIndex = 66;
                break;
            case "Snake7":
                wayPointIndex = 75;
                break;
            case "Snake8":
                wayPointIndex = 5;
                break;
            case "Snake9":
                wayPointIndex = 47;
                break;
            case "Snake10":
                wayPointIndex = 30;
                break;
        }
        return wayPointIndex;
    }
    int AsignLadder(string LadderName)
    {
        int wayPointIndex = 0;
        switch (LadderName)
        {
            case "Ladder1":
                wayPointIndex = 15;

                break;
            case "Ladder2":
                wayPointIndex = 28;
                break;
            case "Ladder3":
                wayPointIndex = 63;
                break;
            case "Ladder4":
                wayPointIndex = 45;
                break;
            case "Ladder5":
                wayPointIndex = 31;
                break;
            case "Ladder6":
                wayPointIndex = 59;
                break;
            case "Ladder7":
                wayPointIndex = 55;
                break;
            case "Ladder8":
                wayPointIndex = 67;
                break;
            case "Ladder9":
                wayPointIndex = 61;
                break;
            case "Ladder10":
                wayPointIndex = 73;
                break;
            case "Ladder11":
                wayPointIndex = 98;
                break;
            case "Ladder12":
                wayPointIndex = 94;
                break;
            case "Ladder13":
                wayPointIndex = 91;
                break;
        }
        return wayPointIndex;

    }

}
