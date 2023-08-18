using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.UI;


public class PlayerI : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform[] FirstPositions;// 0-3 -> red ,4-7-> green , 8-11 -> yellow , 12-15-> blue
    public static int[] currentIndex = new int[16];  // 0-3 -> red ,4-7-> green , 8-11 -> yellow , 12-15-> blue 
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
    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            alive[i] = false;
            currentIndex[i] = 0;
        }
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
                    currentIndex[0] = 0;
                    a.gameObject.transform.position = FirstPositions[0].position;
                    alive[0] = false;
                }
                if (a.gameObject.name == "RED2")
                {
                    currentIndex[1] = 0;
                    a.gameObject.transform.position = FirstPositions[1].position;
                    alive[1] = false;
                }
                if (a.gameObject.name == "RED3")
                {
                    currentIndex[2] = 0;
                    a.gameObject.transform.position = FirstPositions[2].position;
                    alive[2] = false;
                }
                if (a.gameObject.name == "RED4")
                {
                    currentIndex[3] = 0;
                    a.gameObject.transform.position = FirstPositions[3].position;
                    alive[3] = false;
                }
                if (a.gameObject.name == "GREEN1")
                {
                    currentIndex[4] = 0;
                    a.gameObject.transform.position = FirstPositions[4].position;
                    alive[4] = false;
                }
                if (a.gameObject.name == "GREEN2")
                {
                    currentIndex[5] = 0;
                    a.gameObject.transform.position = FirstPositions[5].position;
                    alive[5] = false;
                }
                if (a.gameObject.name == "GREEN3")
                {
                    currentIndex[6] = 0;
                    a.gameObject.transform.position = FirstPositions[6].position;
                    alive[6] = false;
                }
                if (a.gameObject.name == "GREEN4")
                {
                    currentIndex[7] = 0;
                    a.gameObject.transform.position = FirstPositions[7].position;
                    alive[7] = false;
                }
                if (a.gameObject.name == "YELLOW1")
                {
                    currentIndex[8] = 0;
                    a.gameObject.transform.position = FirstPositions[8].position;
                    alive[8] = false;
                }
                if (a.gameObject.name == "YELLOW2")
                {
                    currentIndex[9] = 0;
                    a.gameObject.transform.position = FirstPositions[9].position;
                    alive[9] = false;
                }
                if (a.gameObject.name == "YELLOW3")
                {
                    currentIndex[10] = 0;
                    a.gameObject.transform.position = FirstPositions[10].position;
                    alive[10] = false;
                }
                if (a.gameObject.name == "YELLOW4")
                {
                    currentIndex[11] = 0;
                    a.gameObject.transform.position = FirstPositions[11].position;
                    alive[11] = false;
                }
                
           
                if (a.gameObject.name == "BLUE1")
                {
                    currentIndex[12] = 0;
                    a.gameObject.transform.position = FirstPositions[12].position;
                    alive[12] = false;
                }
                if (a.gameObject.name == "BLUE2")
                {
                    currentIndex[13] = 0;
                    a.gameObject.transform.position = FirstPositions[13].position;
                    alive[13] = false;
                }
                if (a.gameObject.name == "BLUE3")
                {
                    currentIndex[14] = 0;
                    a.gameObject.transform.position = FirstPositions[14].position;
                    alive[14] = false;
                }
                if (a.gameObject.name == "BLUE4")
                {
                    currentIndex[15] = 0;
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
                            lastIndex = currentIndex[0];
                            currentIndex[0] += rand1;
                            transform.position = wayPoints[currentIndex[0]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[0] = true;
                        lastIndex = currentIndex[0];
                        transform.position = wayPoints[currentIndex[0]].position;
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
                            lastIndex = currentIndex[1];
                            currentIndex[1] += rand1;
                            transform.position = wayPoints[currentIndex[1]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[1] = true;
                        lastIndex = currentIndex[1];
                        transform.position = wayPoints[currentIndex[1]].position;
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
                            lastIndex = currentIndex[2];
                            currentIndex[2] += rand1;
                            transform.position = wayPoints[currentIndex[2]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[2] = true;
                        lastIndex = currentIndex[2];
                        transform.position = wayPoints[currentIndex[2]].position;
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
                            lastIndex = currentIndex[3];
                            currentIndex[3] += rand1;
                            transform.position = wayPoints[currentIndex[3]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand1 == 6)
                    {
                        alive[3] = true;
                        lastIndex = currentIndex[3];
                        transform.position = wayPoints[currentIndex[3]].position;
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
                            lastIndex = currentIndex[4];
                            currentIndex[4] += rand2;
                            transform.position = wayPoints[currentIndex[4]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[4] = true;
                        lastIndex = currentIndex[4];
                        transform.position = wayPoints[currentIndex[4]].position;
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
                            lastIndex = currentIndex[5];
                            currentIndex[5] += rand2;
                            transform.position = wayPoints[currentIndex[5]].position;
                            Turn_Ludo.turnChange();
                        }

                    }
                    else if (rand2 == 6)
                    {
                        alive[5] = true;
                        lastIndex = currentIndex[5];
                        transform.position = wayPoints[currentIndex[5]].position;
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
                            lastIndex = currentIndex[6];
                            currentIndex[6] += rand2;
                            transform.position = wayPoints[currentIndex[6]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[6] = true;
                        lastIndex = currentIndex[6];
                        transform.position = wayPoints[currentIndex[6]].position;
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
                            lastIndex = currentIndex[7];
                            currentIndex[7] += rand2;
                            transform.position = wayPoints[currentIndex[7]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand2 == 6)
                    {
                        alive[7] = true;
                        lastIndex = currentIndex[7];
                        transform.position = wayPoints[currentIndex[7]].position;
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
                            lastIndex = currentIndex[8];
                            currentIndex[8] += rand3;
                            transform.position = wayPoints[currentIndex[8]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[8] = true;
                        lastIndex = currentIndex[8];
                        transform.position = wayPoints[currentIndex[8]].position;
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
                            lastIndex = currentIndex[9];
                            currentIndex[9] += rand3;
                            transform.position = wayPoints[currentIndex[9]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[9] = true;
                        lastIndex = currentIndex[9];
                        transform.position = wayPoints[currentIndex[9]].position;
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
                            lastIndex = currentIndex[10];
                            currentIndex[10] += rand3;
                            transform.position = wayPoints[currentIndex[10]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[10] = true;
                        lastIndex = currentIndex[10];
                        transform.position = wayPoints[currentIndex[10]].position;
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
                            lastIndex = currentIndex[11];
                            currentIndex[11] += rand3;
                            transform.position = wayPoints[currentIndex[11]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand3 == 6)
                    {
                        alive[11] = true;
                        lastIndex = currentIndex[11];
                        transform.position = wayPoints[currentIndex[11]].position;
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
                            lastIndex = currentIndex[12];
                            currentIndex[12] += rand4;
                            transform.position = wayPoints[currentIndex[12]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[12] = true;
                        lastIndex = currentIndex[12];
                        transform.position = wayPoints[currentIndex[12]].position;
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
                            lastIndex = currentIndex[13];
                            currentIndex[13] += rand4;
                            transform.position = wayPoints[currentIndex[13]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[13] = true;
                        lastIndex = currentIndex[13];
                        transform.position = wayPoints[currentIndex[13]].position;
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
                            lastIndex = currentIndex[14];
                            currentIndex[14] += rand4;
                            transform.position = wayPoints[currentIndex[14]].position;
                            Turn_Ludo.turnChange();
                        }
                    }
                    else if (rand4 == 6)
                    {
                        alive[14] = true;
                        lastIndex = currentIndex[14];
                        transform.position = wayPoints[currentIndex[14]].position;
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
                            lastIndex = currentIndex[15];
                            currentIndex[15] += rand4;
                            transform.position = wayPoints[currentIndex[15]].position;
                            Turn_Ludo.turnChange();
                        }

                    }
                    else if (rand4 == 6)
                    {
                        alive[15] = true;
                        lastIndex = currentIndex[15];
                        transform.position = wayPoints[currentIndex[15]].position;
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
                    if (currentIndex[i]<52 && currentIndex[i] >= maxVal)
                    {
                        maxVal = currentIndex[i];
                        maxIndex = i % 4;
                    }
                }
                RedPlayers[maxIndex].onClick.Invoke();
                break;
            case "GreenPlayers":
                for (int i = 4; i <= 7; i++)
                {
                    if (currentIndex[i] < 52 && currentIndex[i] >= maxVal)
                    {
                        maxVal = currentIndex[i];
                        maxIndex = i % 4;
                    }
                }
                GreenPlayers[maxIndex].onClick.Invoke();
                break;

            case "BluePlayers":
                for (int i = 12; i <= 15; i++)
                {
                    if (currentIndex[i] < 52 && currentIndex[i] >= maxVal)
                    {
                        maxVal = currentIndex[i];
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
                if (currentIndex[0] + rand1 != currentIndex[1] && currentIndex[0] + rand1 != currentIndex[2] && currentIndex[0] + rand1 != currentIndex[3])
                    return true;
                else
                    return false;
                break;
            case "Red2":
                if (currentIndex[1] + rand1 != currentIndex[0] && currentIndex[1] + rand1 != currentIndex[2] && currentIndex[1] + rand1 != currentIndex[3])
                    return true;
                else
                    return false;
                break;
            case "Red3":
                if (currentIndex[2] + rand1 != currentIndex[0] && currentIndex[2] + rand1 != currentIndex[3] && currentIndex[2] + rand1 != currentIndex[1])
                    return true;
                else
                    return false;
                break;
            case "Red4":
                if (currentIndex[3] + rand1 != currentIndex[0] && currentIndex[3] + rand1 != currentIndex[2] && currentIndex[3] + rand1 != currentIndex[1])
                    return true;
                else
                    return false;
                break;
            case "Green1":
                if (currentIndex[4] + rand2 != currentIndex[5] && currentIndex[4] + rand2 != currentIndex[6] && currentIndex[4] + rand2 != currentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green2":
                if (currentIndex[5] + rand2 != currentIndex[4] && currentIndex[5] + rand2 != currentIndex[6] && currentIndex[5] + rand2 != currentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green3":
                if (currentIndex[6] + rand2 != currentIndex[4] && currentIndex[6] + rand2 != currentIndex[5] && currentIndex[6] + rand2 != currentIndex[7])
                    return true;
                else
                    return false;
                break;
            case "Green4":
                if (currentIndex[7] + rand2 != currentIndex[5] && currentIndex[7] + rand2 != currentIndex[6] && currentIndex[7] + rand2 != currentIndex[4])
                    return true;
                else
                    return false;
                break;
            case "Yellow1":
                if (currentIndex[8] + rand3 != currentIndex[9] && currentIndex[8] + rand3 != currentIndex[10] && currentIndex[8] + rand3 != currentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow2":
                if (currentIndex[9] + rand3 != currentIndex[8] && currentIndex[9] + rand3 != currentIndex[10] && currentIndex[9] + rand3 != currentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow3":
                if (currentIndex[10] + rand3 != currentIndex[8] && currentIndex[10] + rand3 != currentIndex[9] && currentIndex[10] + rand3 != currentIndex[11])
                    return true;
                else
                    return false;
                break;
            case "Yellow4":
                if (currentIndex[11] + rand3 != currentIndex[8] && currentIndex[11] + rand3 != currentIndex[9] && currentIndex[11] + rand3 != currentIndex[10])
                    return true;
                else
                    return false;
                break;
            case "Blue1":
                if (currentIndex[12] + rand4 != currentIndex[13] && currentIndex[12] + rand4 != currentIndex[14] && currentIndex[12] + rand4 != currentIndex[15])
                    return true;
                else
                    return false;
                break;
            case "Blue2":
                if (currentIndex[13] + rand4 != currentIndex[14] && currentIndex[13] + rand4 != currentIndex[15] && currentIndex[13] + rand4 != currentIndex[12])
                    return true;
                else
                    return false;
                break;
            case "Blue3":
                if (currentIndex[14] + rand4 != currentIndex[12] && currentIndex[14] + rand4 != currentIndex[13] && currentIndex[14] + rand4 != currentIndex[15])
                    return true;
                else
                    return false;
                break;
            case "Blue4":
                if (currentIndex[15] + rand4 != currentIndex[12] && currentIndex[15] + rand4 != currentIndex[13] && currentIndex[15] + rand4 != currentIndex[14])
                    return true;
                else
                    return false;
                break;
            default: return false;
        }
    }
    void WhoWinn()
    { 
         if (currentIndex[0] >= 52 
            && currentIndex[1] >= 52 
            && currentIndex[2] >= 52 
            && currentIndex[3] >= 52 )
         {
                //redWin = true;
                winR.enabled = true;
         }
        if (currentIndex[4] >= 52 
            && currentIndex[5] >= 52
            && currentIndex[6] >= 52
            && currentIndex[7] >= 52 )
        {
           // redWin = true;
            winG.enabled = true;
        }
        if (currentIndex[8] >= 52 
            && currentIndex[9] >= 52
            && currentIndex[10] >= 52 
            && currentIndex[11] >= 52 )
        {
           // redWin = true;
            winY.enabled = true;
        }
        if (currentIndex[12] >= 52 
            && currentIndex[13] >= 52 
            && currentIndex[14] >= 52  
            && currentIndex[15] >= 52)
        {
            //redWin = true;
            winB.enabled = true;
        }

    }
    
    void Hit()
    {
        
        if (gameObject.tag == "Reds")
        {
            for(int i = 0; i <= 3; i++)
            {
               
                if (Vector2.Distance(gameObject.transform.position, GreenPlayers[i].transform.position) < 10f)
                {
                   
                    currentIndex[i+4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i+4].position;
                    alive[i+4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) < 10f)
                {
                   
                    currentIndex[i+8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i+8].position;
                    alive[i+8] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    
                    currentIndex[i+12] = 0;
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
                   
                    currentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) < 10f)
                {

                    currentIndex[i + 8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i + 8].position;
                    alive[i + 8] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    currentIndex[i + 12] = 0;
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
                    currentIndex[i + 4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i + 4].position;
                    alive[i + 4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, RedPlayers[i].transform.position) < 10f)
                {
                    currentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, BluePlayers[i].transform.position) < 10f)
                {
                    currentIndex[i + 12] = 0;
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
                    currentIndex[i + 4] = 0;
                    GreenPlayers[i].transform.position = FirstPositions[i + 4].position;
                    alive[i + 4] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, RedPlayers[i].transform.position) < 10f)
                {
                    currentIndex[i] = 0;
                    RedPlayers[i].transform.position = FirstPositions[i].position;
                    alive[i] = false;
                }
                else if (Vector2.Distance(gameObject.transform.position, YellowPlayers[i].transform.position) <10f)
                {
                    currentIndex[i + 8] = 0;
                    YellowPlayers[i].transform.position = FirstPositions[i + 8].position;
                    alive[i + 8] = false;
                }
            }
        }
    }
 
}
 
