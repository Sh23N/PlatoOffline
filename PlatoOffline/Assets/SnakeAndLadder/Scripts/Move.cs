using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public static int rand0 ;
    public static int rand1 ;
 
    Transform target;
    int wayPointIndex = 0;

    public static bool noMoveForIt1;
    public static bool noMoveForIt0 ;

    int stay = 0;

    public static bool hasWiner;

    public GameObject WinCanvas;
    public TMP_Text WinerText;
    // Start is called before the first frame update
    void Start()
    {
        hasWiner = false;
        print(gameObject.name);
        target = way.points[0];
        WinCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {  if (!hasWiner)
        {
            stay = 0;

            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * 300 * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.8f)
            {

                GetNextPoint();
                stay = 1;
            }
        }
      
    }
    void GetNextPoint()
    {
        if (gameObject.name == "Player0")
        {
            if (wayPointIndex + rand0 <= 99)
            {
                for (int i = 0; i < rand0; i++)
                {
                    if (noMoveForIt0)
                    {
                        wayPointIndex++;
                        // print(wayPointIndex + "getNext");
                        target = way.points[wayPointIndex];
                    }
                }
                noMoveForIt0 = false;
            }        
        }
        if (gameObject.name == "Player1")
        {
            if (wayPointIndex + rand1 <= 99)
            {
                for (int i = 0; i < rand1; i++)
                {
                    if (noMoveForIt1)
                    {
                        wayPointIndex++;
                        // print(wayPointIndex + "getNext");
                        target = way.points[wayPointIndex];
                    }
                }
                noMoveForIt1 = false;
            }
        }

    }
    void OnCollisionStay2D(Collision2D a)
    {
        if (a.gameObject.tag == "snake" && stay == 1 && !hasWiner)
        {
            AsignTail(a.gameObject.name);
            target = way.points[wayPointIndex];
        }
        else if (a.gameObject.tag == "ladder" && stay == 1 && !hasWiner)
        {
            AsignLadder(a.gameObject.name);
            target = way.points[wayPointIndex];
        }
        else if (a.gameObject.tag == "WinSq" && stay == 1 && !hasWiner)
        {
            print("winer is" + gameObject.name);
            hasWiner = true;
            WinCanvas.SetActive(true);
            if (gameObject.name == "Player0")
                WinerText.text = "System";
            else if(gameObject.name == "Player1")
                WinerText.text = "You";
        }
            target = way.points[wayPointIndex];
    }
    void AsignTail(string SnakeName)
    {
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
    }
   void AsignLadder(string LadderName)
    {
       // stay = 1;
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
        
        }
   //write function to menu and retry!!!!
}

