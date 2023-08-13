using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class PlayerI : MonoBehaviour
{
    public Transform[] wayPoints;
    int currentIndex;
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

    public GameObject[] RedPlayers;
    public GameObject[] GreenPlayers;
    public GameObject[] YellowPlayers;
    public GameObject[] BluePlayers;

    //public static bool[] RedDestinations;
    public static int RedDestinationsCount;

   // public static bool[] GreenDestinations;
    public static int GreenDestinationsCount;

   // public static bool[] YellowDestinations;
    public static int YellowDestinationsCount;

   // public static bool[] BlueDestinations;
    public static int BlueDestinationsCount;

    public Image winR;
    public Image winG;
    public Image winY;
    public Image winB;

    // Start is called before the first frame update
    void Start()
    {
      // Death = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
       
    }
    void OnCollisionEnter2D(Collision2D a)
    {
        /*  print("hitt");
          print("t"+ Turn_Ludo.whoTurn);
          print("tag" + gameObject.tag);*/

        /* if (currentIndex < 52 && ( (gameObject.tag == "Reds" && Turn_Ludo.whoTurn == 1) || (gameObject.tag == "Greens" && Turn_Ludo.whoTurn == 2) || 
             (gameObject.tag == "Yellows" && Turn_Ludo.whoTurn == 3) || (gameObject.tag == "Blues" && Turn_Ludo.whoTurn == 4) ))
         {  a.gameObject.SetActive(false);
             print("Dddd");*/
        // if(whoturn==true) !!!!!
        /*  transform.position = wayPoints[lastIndex].position;
          if (turn.whoturn != 1 && a.gameObject.tag == "Reds")
              a.gameObject.Setactive(false);
          if (turn.whoturn != 2 && a.gameObject.tag == "Greens")*/
        // }
       
        if (a.gameObject.tag == "Destination")
        {
           switch(gameObject.tag)
           {
                case "Reds":
                   /* if (!RedDestinations[RedDestinationsCount])
                    {
                        RedDestinations[RedDestinationsCount] = true;*/
                        RedDestinationsCount++;
                        NextPlayer();
                    if (gameObject.name=="Red4")
                    {
                        winR.enabled = true;
                    }
                   
                    break;
                case "Greens":
                   /* if (!GreenDestinations[GreenDestinationsCount])
                    {
                        GreenDestinations[GreenDestinationsCount] = true;*/
                        GreenDestinationsCount++;
                        NextPlayer();
                    if (gameObject.name == "Green4")
                    {
                        winG.enabled = true;
                    }
                    break;
                case "Yellows":
                   /* if (!YellowDestinations[YellowDestinationsCount])
                    {
                        YellowDestinations[YellowDestinationsCount] = true;*/
                        YellowDestinationsCount++;
                        NextPlayer();
                    if (gameObject.name == "Yellow4")
                    {
                        winY.enabled = true;
                    }
                    break;
                case "Blues":
                  /*  if (!BlueDestinations[BlueDestinationsCount])
                    {
                        BlueDestinations[BlueDestinationsCount] = true;*/
                        BlueDestinationsCount++;
                        NextPlayer();
                    if (gameObject.name == "Blue4")
                    {
                        winB.enabled = true;
                    }
                    break;

           }
        }
        else
        {
            if (!hitt)
            {
                lastIndex = 0;
                currentIndex = 0;
                transform.position = wayPoints[currentIndex].position;
                hitt=true;
            }
        }
    }
    public void move()
    {   /* if (((gameObject.tag == "Reds" && Turn_Ludo.whoTurn == 1) || (gameObject.tag == "Greens" && Turn_Ludo.whoTurn == 2) ||
            (gameObject.tag == "Yellows" && Turn_Ludo.whoTurn == 3) || (gameObject.tag == "Blues" && Turn_Ludo.whoTurn == 4)))
      {*/
        if (gameObject.tag == "Reds" && noMoveForIt1)
        {
          /*  if (rand1 == 6)
                six1 = true;*/
            if (rand1 >= 0 && rand1+lastIndex < wayPoints.Length)
            {
                lastIndex = currentIndex;
                currentIndex += rand1;
                transform.position = wayPoints[currentIndex].position;
            }
            noMoveForIt1 = false;
        }
        if (gameObject.tag == "Greens"  && noMoveForIt2)
        {
            /*if (rand2 == 6)
                Death = false;*/
            if (rand2 >= 0 && rand2 + lastIndex < wayPoints.Length)
            {
                lastIndex = currentIndex;
                currentIndex += rand2;
                transform.position = wayPoints[currentIndex].position;
            }
            noMoveForIt2 = false;
        }
        if (gameObject.tag == "Yellows" && noMoveForIt3)
        {
           /* if (rand3 == 6)
                Death = false;*/
            if (rand3 >= 0 && rand3 + lastIndex < wayPoints.Length)
            {
                lastIndex = currentIndex;
                currentIndex += rand3;
                transform.position = wayPoints[currentIndex].position;
            
            }
            noMoveForIt3 = false;
        }
        if (gameObject.tag == "Blues"  && noMoveForIt4)
        {
            /*if (rand4 == 6)
                Death = false;*/
            if (rand4 >= 0 && rand4 + lastIndex < wayPoints.Length)
            {
                lastIndex = currentIndex;
                currentIndex += rand4;
                transform.position = wayPoints[currentIndex].position;
            }
            noMoveForIt4 = false;
        }


    }
      void NextPlayer()
      {
        if (gameObject.tag == "Reds")
        {
            if (gameObject.name == "Red1")
            {
                RedPlayers[1].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
                print("creatRed2...............");
            }
            else if (gameObject.name == "Red2")
            {
                RedPlayers[2].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Red3")
            {
                RedPlayers[3].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Red4")
            {
                RedPlayers[0].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameObject.tag == "Greens")
        {
            if (gameObject.name == "Green1")
            {
                GreenPlayers[1].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Green2")
            {
                GreenPlayers[2].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Green3")
            {
                GreenPlayers[3].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Green4")
            {
                GreenPlayers[0].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameObject.tag == "Yellows")
        {
            if (gameObject.name == "Yellow1")
            {
                YellowPlayers[1].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
           else  if (gameObject.name == "Yellow2")
            {
                YellowPlayers[2].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Yellow3")
            {
                YellowPlayers[3].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Yellow4")
            {
                YellowPlayers[0].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameObject.tag == "Blues")
        {
            if (gameObject.name == "Blue1")
            {
                BluePlayers[1].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Blue2")
            {
                BluePlayers[2].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Blue3")
            {
                BluePlayers[3].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (gameObject.name == "Blue4")
            {
                BluePlayers[0].SetActive(true);
                GetComponent<PlayerI>().enabled = false;//destroy this script!!
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

      }
    }
