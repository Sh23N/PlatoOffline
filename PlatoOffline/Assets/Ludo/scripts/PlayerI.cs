using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class PlayerI : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform[] FirstPositions;// 0-3 -> red ,4-7-> green , 8-11 -> yellow , 12-15-> blue
    public static int[] curcurrentIndex = new int[16];  // 0-3 -> red ,4-7-> green , 8-11 -> yellow , 12-15-> blue 
    public static bool[] alive = new bool[16]; // 0-3 -> red ,4-7-> green , 8-11 -> yellow , 12-15-> blue

    bool notEmpty;
    int lastIndex;

    public static bool hitt;

    public static int rand1;
    public static int rand2;
    public static int rand3;
    public static int rand4;

    public static bool noMoveForIt1;
    public static bool noMoveForIt2;
    public static bool noMoveForIt3;
    public static bool noMoveForIt4;

    public Button[] RedPlayers;
    public Button[] GreenPlayers;
    public Button[] YellowPlayers;
    public Button[] BluePlayers;

    public static int RedDestinationsCount;

    public static int GreenDestinationsCount;

    public static int YellowDestinationsCount;

    public static int BlueDestinationsCount;

    public Image winR;
    public Image winG;
    public Image winY;
    public Image winB;

   
    bool dynamic;
    public static bool hit;

    public Button RollButt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        WhoWinn();
        if (Turn_Ludo.whoTurn == 1 || Turn_Ludo.whoTurn == 4 || Turn_Ludo.whoTurn == 2)
        {
            OnClickPlayerSystem();
        }


    }
    /*void OnCollisionEnter2D(Collision2D a)
    {
           print("hitt");
      //  if (!hitt)
        //{
            if (IsMyTurn())
            {
                if (a.gameObject.name == "RED1")
                {
                    print("hitt1");
                    curcurrentIndex[0] = 0;
                    a.gameObject.transform.position = FirstPositions[0].position;
                    alive[0] = false;
                }
                if (a.gameObject.name == "RED2")
                {
                    curcurrentIndex[1] = 0;
                    a.gameObject.transform.position = FirstPositions[1].position;
                    alive[1] = false;
                }
                if (a.gameObject.name == "RED3")
                {
                    curcurrentIndex[2] = 0;
                    a.gameObject.transform.position = FirstPositions[2].position;
                    alive[2] = false;
                }
                if (a.gameObject.name == "RED4")
                {
                    curcurrentIndex[3] = 0;
                    a.gameObject.transform.position = FirstPositions[3].position;
                    alive[3] = false;
                }
                if (a.gameObject.name == "GREEN1")
                {
                    curcurrentIndex[4] = 0;
                    a.gameObject.transform.position = FirstPositions[4].position;
                    alive[4] = false;
                }
                if (a.gameObject.name == "GREEN2")
                {
                    curcurrentIndex[5] = 0;
                    a.gameObject.transform.position = FirstPositions[5].position;
                    alive[5] = false;
                }
                if (a.gameObject.name == "GREEN3")
                {
                    curcurrentIndex[6] = 0;
                    a.gameObject.transform.position = FirstPositions[6].position;
                    alive[6] = false;
                }
                if (a.gameObject.name == "GREEN4")
                {
                    curcurrentIndex[7] = 0;
                    a.gameObject.transform.position = FirstPositions[7].position;
                    alive[7] = false;
                }
                if (a.gameObject.name == "YELLOW1")
                {
                    curcurrentIndex[8] = 0;
                    a.gameObject.transform.position = FirstPositions[8].position;
                    alive[8] = false;
                }
                if (a.gameObject.name == "YELLOW2")
                {
                    curcurrentIndex[9] = 0;
                    a.gameObject.transform.position = FirstPositions[9].position;
                    alive[9] = false;
                }
                if (a.gameObject.name == "YELLOW3")
                {
                    curcurrentIndex[10] = 0;
                    a.gameObject.transform.position = FirstPositions[10].position;
                    alive[10] = false;
                }
                if (a.gameObject.name == "YELLOW4")
                {
                    curcurrentIndex[11] = 0;
                    a.gameObject.transform.position = FirstPositions[11].position;
                    alive[11] = false;
                }
                
           
                if (a.gameObject.name == "BLUE1")
                {
                    curcurrentIndex[12] = 0;
                    a.gameObject.transform.position = FirstPositions[12].position;
                    alive[12] = false;
                }
                if (a.gameObject.name == "BLUE2")
                {
                    curcurrentIndex[13] = 0;
                    a.gameObject.transform.position = FirstPositions[13].position;
                    alive[13] = false;
                }
                if (a.gameObject.name == "BLUE3")
                {
                    curcurrentIndex[14] = 0;
                    a.gameObject.transform.position = FirstPositions[14].position;
                    alive[14] = false;
                }
                if (a.gameObject.name == "BLUE4")
                {
                    curcurrentIndex[15] = 0;
                    a.gameObject.transform.position = FirstPositions[15].position;
                    alive[15] = false;
                }
              
            }
            
      //  }
    }*/
    public void moveP()
    {
        if (gameObject.tag == "Reds" && noMoveForIt1)
        {

            if (rand1 >= 0 && rand1 + lastIndex < wayPoints.Length)
            {
                if (gameObject.name == "RED1")
                {
                    dynamic = true;
                    if (alive[0])
                    {
                        if (CanGo("Red1"))
                        {
                            lastIndex = curcurrentIndex[0];
                            curcurrentIndex[0] += rand1;
                            transform.position = wayPoints[curcurrentIndex[0]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[0] = true;
                        lastIndex = curcurrentIndex[0];
                        transform.position = wayPoints[curcurrentIndex[0]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic = false;

                }
                else if (gameObject.name == "RED2")
                {   dynamic = true;
                    if (alive[1])
                    {
                        if (CanGo("Red2"))
                        {
                            lastIndex = curcurrentIndex[1];
                            curcurrentIndex[1] += rand1;
                            transform.position = wayPoints[curcurrentIndex[1]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[1] = true;
                        lastIndex = curcurrentIndex[1];
                        transform.position = wayPoints[curcurrentIndex[1]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic =false;
                }
                else if (gameObject.name == "RED3")
                {   dynamic = true;
                    if (alive[2])
                    {
                        if (CanGo("Red3"))
                        {
                            lastIndex = curcurrentIndex[2];
                            curcurrentIndex[2] += rand1;
                            transform.position = wayPoints[curcurrentIndex[2]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[2] = true;
                        lastIndex = curcurrentIndex[2];
                        transform.position = wayPoints[curcurrentIndex[2]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic =false;

                }
                else if (gameObject.name == "RED4")
                {   dynamic = true;
                    if (alive[3])
                    {
                        if (CanGo("Red4"))
                        {
                            lastIndex = curcurrentIndex[3];
                            curcurrentIndex[3] += rand1;
                            transform.position = wayPoints[curcurrentIndex[3]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[3] = true;
                        lastIndex = curcurrentIndex[3];
                        transform.position = wayPoints[curcurrentIndex[3]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic= false;
                }
            }
            
            noMoveForIt1 = false;
           // Turn_Ludo.turnChange();
        }
        if (gameObject.tag == "Greens" && noMoveForIt2)
        {
            if (rand2 >= 0 && rand2 + lastIndex < wayPoints.Length)
            {
                if (gameObject.name == "GREEN1")
                {  dynamic=true;
                    if (alive[4])
                    {
                        if (CanGo("Green1"))
                        {
                            lastIndex = curcurrentIndex[4];
                            curcurrentIndex[4] += rand2;
                            transform.position = wayPoints[curcurrentIndex[4]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[4] = true;
                        lastIndex = curcurrentIndex[4];
                        transform.position = wayPoints[curcurrentIndex[4]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic =false;
                }
                else if (gameObject.name == "GREEN2")
                {
                    dynamic = true;
                    if (alive[5])
                    {
                        if (CanGo("Green2"))
                        {
                            lastIndex = curcurrentIndex[5];
                            curcurrentIndex[5] += rand2;
                            transform.position = wayPoints[curcurrentIndex[5]].position;
                            Turn_Ludo.turnChange();
                        }

                    }
                    else if (rand2 == 6)
                    {
                        alive[5] = true;
                        lastIndex = curcurrentIndex[5];
                        transform.position = wayPoints[curcurrentIndex[5]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "GREEN3")
                {  dynamic= true;
                    if (alive[6])
                    {
                        if (CanGo("Green3"))
                        {
                            lastIndex = curcurrentIndex[6];
                            curcurrentIndex[6] += rand2;
                            transform.position = wayPoints[curcurrentIndex[6]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[6] = true;
                        lastIndex = curcurrentIndex[6];
                        transform.position = wayPoints[curcurrentIndex[6]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "GREEN4")
                {   dynamic = true;
                    if (alive[7])
                    {
                        if (CanGo("Green4"))
                        {
                            lastIndex = curcurrentIndex[7];
                            curcurrentIndex[7] += rand2;
                            transform.position = wayPoints[curcurrentIndex[7]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[7] = true;
                        lastIndex = curcurrentIndex[7];
                        transform.position = wayPoints[curcurrentIndex[7]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic =false;
                }

            }
            noMoveForIt2 = false;
           // Turn_Ludo.turnChange();
        }
        if (gameObject.tag == "Yellows" && noMoveForIt3)
        {
            if (rand3 >= 0 && rand3 + lastIndex < wayPoints.Length)
            {

                if (gameObject.name == "YELLOW1")
                {   dynamic=true;
                    if (alive[8])
                    {
                        if (CanGo("Yellow1"))
                        {
                            lastIndex = curcurrentIndex[8];
                            curcurrentIndex[8] += rand3;
                            transform.position = wayPoints[curcurrentIndex[8]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[8] = true;
                        lastIndex = curcurrentIndex[8];
                        transform.position = wayPoints[curcurrentIndex[8]].position;
                        Turn_Ludo.againTurn();//prize
                        RollButt.gameObject.SetActive(true);

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "YELLOW2")
                {  dynamic = true;
                    if (alive[9])
                    {
                        if (CanGo("Yellow2"))
                        {
                            lastIndex = curcurrentIndex[9];
                            curcurrentIndex[9] += rand3;
                            transform.position = wayPoints[curcurrentIndex[9]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[9] = true;
                        lastIndex = curcurrentIndex[9];
                        transform.position = wayPoints[curcurrentIndex[9]].position;
                        Turn_Ludo.againTurn();//prize
                        RollButt.gameObject.SetActive(true);

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "YELLOW3")
                {   dynamic= true;
                    if (alive[10])
                    {
                        if (CanGo("Yellow3"))
                        {
                            lastIndex = curcurrentIndex[10];
                            curcurrentIndex[10] += rand3;
                            transform.position = wayPoints[curcurrentIndex[10]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[10] = true;
                        lastIndex = curcurrentIndex[10];
                        transform.position = wayPoints[curcurrentIndex[10]].position;
                        Turn_Ludo.againTurn();//prize
                        RollButt.gameObject.SetActive(true);

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "YELLOW4")
                {
                    dynamic = true;
                    if (alive[11])
                    {
                        if (CanGo("Yellow4"))
                        {
                            lastIndex = curcurrentIndex[11];
                            curcurrentIndex[11] += rand3;
                            transform.position = wayPoints[curcurrentIndex[11]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[11] = true;
                        lastIndex = curcurrentIndex[11];
                        transform.position = wayPoints[curcurrentIndex[11]].position;
                        Turn_Ludo.againTurn();//prize
                        RollButt.gameObject.SetActive(true);

                    }
                    Hit();
                    dynamic = false;
                }

            }
            noMoveForIt3 = false;
            //Turn_Ludo.turnChange();
        }
        if (gameObject.tag == "Blues" && noMoveForIt4)
        {
            if (rand4 >= 0 && rand4 + lastIndex < wayPoints.Length)
            {
                if (gameObject.name == "BLUE1")
                {   dynamic = true;
                    if (alive[12])
                    {
                        if (CanGo("Blue1"))
                        {
                            lastIndex = curcurrentIndex[12];
                            curcurrentIndex[12] += rand4;
                            transform.position = wayPoints[curcurrentIndex[12]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[12] = true;
                        lastIndex = curcurrentIndex[12];
                        transform.position = wayPoints[curcurrentIndex[12]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "BLUE2")
                {   dynamic= true;
                    if (alive[13])
                    {
                        if (CanGo("Blue2"))
                        {
                            lastIndex = curcurrentIndex[13];
                            curcurrentIndex[13] += rand4;
                            transform.position = wayPoints[curcurrentIndex[13]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[13] = true;
                        lastIndex = curcurrentIndex[13];
                        transform.position = wayPoints[curcurrentIndex[13]].position;
                        Turn_Ludo.againTurn();//prize
                    }
                    Hit();
                    dynamic = false;
                }
                else if (gameObject.name == "BLUE3")
                {   dynamic= false;
                    if (alive[14])
                    {
                        if (CanGo("Blue3"))
                        {
                            lastIndex = curcurrentIndex[14];
                            curcurrentIndex[14] += rand4;
                            transform.position = wayPoints[curcurrentIndex[14]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[14] = true;
                        lastIndex = curcurrentIndex[14];
                        transform.position = wayPoints[curcurrentIndex[14]].position;
                        Turn_Ludo.againTurn();//prize
                    }
                    Hit();
                    dynamic =false;
                }
                else if (gameObject.name == "BLUE4")
                {   dynamic= false;
                    if (alive[15])
                    {
                        if (CanGo("Blue4"))
                        {
                            lastIndex = curcurrentIndex[15];
                            curcurrentIndex[15] += rand4;
                            transform.position = wayPoints[curcurrentIndex[15]].position;
                            Turn_Ludo.turnChange();
                        }

                    }
                    else if (rand4 == 6)
                    {
                        alive[15] = true;
                        lastIndex = curcurrentIndex[15];
                        transform.position = wayPoints[curcurrentIndex[15]].position;
                        Turn_Ludo.againTurn();//prize

                    }
                    Hit();
                    dynamic = false;
                }
            }
            noMoveForIt4 = false;
           // Turn_Ludo.turnChange();
        }


    }
   
    public void OnClickPlayerSystem()
    {
        if (Turn_Ludo.whoTurn == 1)
            BetterPiceTomMove("Red");
        else if (Turn_Ludo.whoTurn == 2)
            BetterPiceTomMove("Green");
        else if (Turn_Ludo.whoTurn == 4)
            BetterPiceTomMove("Blue");
    }
    public void OnClickPlayer()
    {
        moveP();
    }
    int BetterPiceTomMove(string team)
    {
        int maxVal = 0;
        int maxIndex = 0;
        switch (team + "Players")
        {
            case "RedPlayers":
                for (int i = 0; i <= 3; i++)
                {
                    if (curcurrentIndex[i]<52 && curcurrentIndex[i] >= maxVal)
                    {
                        maxVal = curcurrentIndex[i];
                        maxIndex = i % 4;
                    }
                }
                RedPlayers[maxIndex].onClick.Invoke();
                break;
            case "GreenPlayers":
                for (int i = 4; i <= 7; i++)
                {
                    if (curcurrentIndex[i] < 52 && curcurrentIndex[i] >= maxVal)
                    {
                        maxVal = curcurrentIndex[i];
                        maxIndex = i % 4;
                    }
                }
                GreenPlayers[maxIndex].onClick.Invoke();
                break;

            case "BluePlayers":
                for (int i = 12; i <= 15; i++)
                {
                    if (curcurrentIndex[i] < 52 && curcurrentIndex[i] >= maxVal)
                    {
                        maxVal = curcurrentIndex[i];
                        maxIndex = i % 4;
                    }
                }
                BluePlayers[maxIndex].onClick.Invoke();
                break;

        }
        return maxIndex;
    }
    bool CanGo(string gameObjectName)//dont allow two pieces at a same index
    {
        switch (gameObjectName)
        {
            case "Red1":
                if (curcurrentIndex[0] + rand1 != curcurrentIndex[1] && curcurrentIndex[0] + rand1 != curcurrentIndex[2] && curcurrentIndex[0] + rand1 != curcurrentIndex[3])
                    return true;
                else
                    return false;
                break;
            case "Red2":
                if (curcurrentIndex[1] + rand1 != curcurrentIndex[0] && curcurrentIndex[1] + rand1 != curcurrentIndex[2] && curcurrentIndex[1] + rand1 != curcurrentIndex[3])
                    return true;
                else
                    return false;
                break;
            case "Red3":
                if (curcurrentIndex[2] + rand1 != curcurrentIndex[0] && curcurrentIndex[2] + rand1 != curcurrentIndex[3] && curcurrentIndex[2] + rand1 != curcurrentIndex[1])
                    return true;
                else
                    return false;
                break;
            case "Red4":
                if (curcurrentIndex[3] + rand1 != curcurrentIndex[0] && curcurrentIndex[3] + rand1 != curcurrentIndex[2] && curcurrentIndex[3] + rand1 != curcurrentIndex[1])
                    return true;
                else
                    return false;
                break;
            case "Green1":
                if (curcurrentIndex[4] + rand2 != curcurrentIndex[5] && curcurrentIndex[4] + rand2 != curcurrentIndex[6] && curcurrentIndex[4] + rand2 != curcurrentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green2":
                if (curcurrentIndex[5] + rand2 != curcurrentIndex[4] && curcurrentIndex[5] + rand2 != curcurrentIndex[6] && curcurrentIndex[5] + rand2 != curcurrentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green3":
                if (curcurrentIndex[6] + rand2 != curcurrentIndex[4] && curcurrentIndex[6] + rand2 != curcurrentIndex[5] && curcurrentIndex[6] + rand2 != curcurrentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green4":
                if (curcurrentIndex[7] + rand2 != curcurrentIndex[5] && curcurrentIndex[7] + rand2 != curcurrentIndex[6] && curcurrentIndex[7] + rand2 != curcurrentIndex[4])
                    return true;
                else
                    return false;
                break;
            case "Yellow1":
                if (curcurrentIndex[8] + rand3 != curcurrentIndex[9] && curcurrentIndex[8] + rand3 != curcurrentIndex[10] && curcurrentIndex[8] + rand3 != curcurrentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow2":
                if (curcurrentIndex[9] + rand3 != curcurrentIndex[8] && curcurrentIndex[9] + rand3 != curcurrentIndex[10] && curcurrentIndex[9] + rand3 != curcurrentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow3":
                if (curcurrentIndex[10] + rand3 != curcurrentIndex[8] && curcurrentIndex[10] + rand3 != curcurrentIndex[9] && curcurrentIndex[10] + rand3 != curcurrentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow4":
                if (curcurrentIndex[11] + rand3 != curcurrentIndex[8] && curcurrentIndex[11] + rand3 != curcurrentIndex[9] && curcurrentIndex[11] + rand3 != curcurrentIndex[10])
                    return true;
                else
                    return false;
                break;
            case "Blue1":
                if (curcurrentIndex[12] + rand4 != curcurrentIndex[13] && curcurrentIndex[12] + rand4 != curcurrentIndex[14] && curcurrentIndex[12] + rand4 != curcurrentIndex[15])
                    return true;
                else
                    return false;
                break;
            case "Blue2":
                if (curcurrentIndex[13] + rand4 != curcurrentIndex[14] && curcurrentIndex[13] + rand4 != curcurrentIndex[15] && curcurrentIndex[13] + rand4 != curcurrentIndex[12])
                    return true;
                else
                    return false;
                break;
            case "Blue3":
                if (curcurrentIndex[14] + rand4 != curcurrentIndex[12] && curcurrentIndex[14] + rand4 != curcurrentIndex[13] && curcurrentIndex[14] + rand4 != curcurrentIndex[15])
                    return true;
                else
                    return false;
                break;
            case "Blue4":
                if (curcurrentIndex[15] + rand4 != curcurrentIndex[12] && curcurrentIndex[15] + rand4 != curcurrentIndex[13] && curcurrentIndex[15] + rand4 != curcurrentIndex[14])
                    return true;
                else
                    return false;
                break;
            default: return false;
        }
    }
    void WhoWinn()
    { 
         if (curcurrentIndex[0] >= 52 
            && curcurrentIndex[1] >= 52 
            && curcurrentIndex[2] >= 52 
            && curcurrentIndex[3] >= 52 )
         {
                //redWin = true;
                winR.enabled = true;
         }
        if (curcurrentIndex[4] >= 52 
            && curcurrentIndex[5] >= 52
            && curcurrentIndex[6] >= 52
            && curcurrentIndex[7] >= 52 )
        {
           // redWin = true;
            winG.enabled = true;
        }
        if (curcurrentIndex[8] >= 52 
            && curcurrentIndex[9] >= 52
            && curcurrentIndex[10] >= 52 
            && curcurrentIndex[11] >= 52 )
        {
           // redWin = true;
            winY.enabled = true;
        }
        if (curcurrentIndex[12] >= 52 
            && curcurrentIndex[13] >= 52 
            && curcurrentIndex[14] >= 52  
            && curcurrentIndex[15] >= 52)
        {
            //redWin = true;
            winB.enabled = true;
        }

    }
    /*bool IsMyTurn()
    {
        if(gameObject.tag=="Reds" && Turn_Ludo.whoTurn==1)
            return true;
        else if (gameObject.tag == "Greens" && Turn_Ludo.whoTurn == 2)
            return true;
        else if (gameObject.tag == "Yellows" && Turn_Ludo.whoTurn == 3)
            return true;
        else if (gameObject.tag == "Blues" && Turn_Ludo.whoTurn == 3)
            return true;
        else
            return false;
    }*/
    void Hit()
    {
        print("llllll");
        if (gameObject.tag == "Reds")
        {
            for(int i = 0; i <= 3; i++)
            {
               
                if (Vector2.Distance(gameObject.transform.position, GreenPlayers[i].transform.position) < 10f)
                {
                   
                    curcurrentIndex[i+4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i+4].position;
                    alive[i+4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) < 10f)
                {
                   
                    curcurrentIndex[i+8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i+8].position;
                    alive[i+8] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    
                    curcurrentIndex[i+12] = 0;
                    BluePlayers[i].transform.position = FirstPositions[i+12].position;
                    alive[i+12] = false;
                }
            }
        }
        else if (gameObject.tag == "Greens")
        {
            
            for (int i = 0; i <= 3; i++)
            {
                if (Vector2.Distance(gameObject.transform.position, RedPlayers[i].transform.position) < 10f)
                {
                   
                    curcurrentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) < 10f)
                {

                    curcurrentIndex[i + 8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i + 8].position;
                    alive[i + 8] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i + 12] = 0;
                    BluePlayers[i].transform.position = FirstPositions[i + 12].position;
                    alive[i + 12] = false;
                }
            }
        }
       else if (gameObject.tag == "Yellows")
        {
            for (int i = 0; i <= 3; i++)
            {
                if (Vector2.Distance(gameObject.transform.position, GreenPlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i + 4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i + 4].position;
                    alive[i + 4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, RedPlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i + 12] = 0;
                    BluePlayers[i].transform.position = FirstPositions[i + 12].position;
                    alive[i + 12] = false;
                }
            }
        }
        else if (gameObject.tag == "Blues")
        {
            for (int i = 0; i <= 3; i++)
            {
                if (Vector2.Distance(gameObject.transform.position, GreenPlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i + 4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i + 4].position;
                    alive[i + 4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, RedPlayers[i].transform.position) < 10f)
                {
                    curcurrentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) <10f)
                {
                    curcurrentIndex[i + 8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i + 8].position;
                    alive[i + 8] = false;
                }
            }
        }
    }
 
}
 
