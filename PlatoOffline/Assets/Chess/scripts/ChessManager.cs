using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChessManager : MonoBehaviour
{
    public Button[] grids;
    public Sprite bishopB , bishopW , pawnB , pawnW , kingB , kingW ,queenB ,queenW,knightB ,knightW ,rookB ,rookW ,yellowFrame ;
    Color color;
    Color noColor;
    public Color Red;//for hit
    public Color Purple;//for check
    public Button b;
    int currentPiece;//index
    Sprite currentSprite;
    bool kingBIsCheck;
    bool kingWIsCheck;
    bool GameIsOver = false;
    public GameObject GameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        GameOver();
    }
    void SetUp()
    {
        color = b.image.color;
        color.a = 1f;
        noColor = b.image.color;
        noColor.a = 0f;
        //set piceses for start game
        grids[0].GetComponent<Image>().sprite = rookB;
        grids[1].GetComponent<Image>().sprite = knightB;
        grids[2].GetComponent<Image>().sprite = bishopB;
        grids[3].GetComponent<Image>().sprite = kingB;
        grids[4].GetComponent<Image>().sprite = queenB;
        grids[5].GetComponent<Image>().sprite = bishopB;
        grids[6].GetComponent<Image>().sprite = knightB;
        grids[7].GetComponent<Image>().sprite = rookB;
        grids[8].GetComponent<Image>().sprite = pawnB;
        grids[9].GetComponent<Image>().sprite = pawnB;
        grids[10].GetComponent<Image>().sprite = pawnB;
        grids[11].GetComponent<Image>().sprite = pawnB;
        grids[12].GetComponent<Image>().sprite = pawnB;
        grids[13].GetComponent<Image>().sprite = pawnB;
        grids[14].GetComponent<Image>().sprite = pawnB;
        grids[15].GetComponent<Image>().sprite = pawnB;

        grids[56].GetComponent<Image>().sprite = rookW;
        grids[57].GetComponent<Image>().sprite = knightW;
        grids[58].GetComponent<Image>().sprite = bishopW;
        grids[59].GetComponent<Image>().sprite = kingW;
        grids[60].GetComponent<Image>().sprite = queenW;
        grids[61].GetComponent<Image>().sprite = bishopW;
        grids[62].GetComponent<Image>().sprite = knightW;
        grids[63].GetComponent<Image>().sprite = rookW;
        grids[48].GetComponent<Image>().sprite = pawnW;
        grids[49].GetComponent<Image>().sprite = pawnW;
        grids[50].GetComponent<Image>().sprite = pawnW;
        grids[51].GetComponent<Image>().sprite = pawnW;
        grids[52].GetComponent<Image>().sprite = pawnW;
        grids[53].GetComponent<Image>().sprite = pawnW;
        grids[54].GetComponent<Image>().sprite = pawnW;
        grids[55].GetComponent<Image>().sprite = pawnW;
        for (int i = 0; i <=15; i++)//blacks
            grids[i].image.color = color;
        for (int i = 48; i <= 63; i++)//wites
            grids[i].image.color = color;
        for(int i=16; i<=47;i++)//no piece on it 
            grids[i].GetComponent<Image>().sprite = null;
    }
    (int , int) Get2DIndex(int k) //convert 1D array index to 2d array index
    {
        int i = k / 8;//col
        int j = k % 8;//row
        return (i, j);
    }
    int Get1DIndex(int i , int j) //convert 2D array index to 1D array index
    {
        return i * 8 + j;
    }
    public void OnClickPiece(int k)
    {
        if (!GameIsOver)
        {
            Sprite s = grids[k].GetComponent<Image>().sprite;
            int i;
            int j;
            (i, j) = Get2DIndex(k);
            if (s == yellowFrame && (s != kingB && s != kingW))//move
            {
                MovePiece(k);
                Check();
                if ((kingBIsCheck && ChessTurn.whoturn == 1) || (kingWIsCheck && ChessTurn.whoturn == 0))//perevent do other moves when checked
                {
                    ClearSprite(k);
                    SetSprite(currentPiece, currentSprite);
                    Check();
                }
                else
                    ChessTurn.turnToggle();
            }

            else if (grids[k].image.color == Red && (s != kingB && s != kingW))//hit
            {
                MovePiece(k);
                Check();
                if ((kingBIsCheck && ChessTurn.whoturn == 1) || (kingWIsCheck && ChessTurn.whoturn == 0))//perevent do other moves when checked
                {
                    SetSprite(k, s);
                    SetSprite(currentPiece, currentSprite);
                    Check();
                }
                else
                    ChessTurn.turnToggle();
            }
            else if (s != null)//click on pieces
            {
                if ((IsWite(k) == 0 && ChessTurn.whoturn == 0) || (IsWite(k) == 1 && ChessTurn.whoturn == 1))
                {
                    ClearValids();
                    currentPiece = k;
                    currentSprite = s;
                    ValidMoves(s, i, j);

                }
            }
        }
       
    }
    void ValidMoves(Sprite type , int i , int j)
    {
      
        if (type == pawnB || type == pawnW)
        {
            PawnValidMoves(type,i,j);
        }
        else if (type == bishopB || type == bishopW)
        {
            BishopValidMoves(type, i, j);
        }
        else if (type == queenB || type == queenW)
        {
            QueenValidMoves(type, i, j);
        }
        else if (type == kingB || type == kingW)
        {
           KingValidMoves(type, i, j);
        }
        else if (type == rookB || type == rookW)
        {
            RookValidMoves(type, i, j);
        }
        else if (type == knightB || type == knightW)
        {
            KnightValidMoves(type, i, j);
        }
        //myButton.interactable = false;
    }
    void KnightValidMoves(Sprite s, int I, int J)
    {
        int u = Get1DIndex(I + 2, J-1);
        if (IsInBound(I+2,J-1))
        {
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
            }
        }
        int u1 = Get1DIndex(I + 2, J + 1);
        if (IsInBound(I + 2, J + 1))
        {
            if (grids[u1].GetComponent<Image>().sprite == null)
                SetSprite(u1, yellowFrame);
            else if (grids[u1].GetComponent<Image>().sprite != null && IsWite(u1) + IsWite(currentPiece) == 1)
            {
                grids[u1].image.color = Red;
            }
        }
        int u2 = Get1DIndex(I-2, J - 1);
        if (IsInBound(I - 2, J - 1))
        {
            if (grids[u2].GetComponent<Image>().sprite == null)
                SetSprite(u2, yellowFrame);
            else if (grids[u2].GetComponent<Image>().sprite != null && IsWite(u2) + IsWite(currentPiece) == 1)
            {
                grids[u2].image.color = Red;
            }
        }
        int u3 = Get1DIndex(I -2, J +1);
        if (IsInBound(I - 2, J + 1))
        {
            if (grids[u3].GetComponent<Image>().sprite == null)
                SetSprite(u3, yellowFrame);
            else if (grids[u3].GetComponent<Image>().sprite != null && IsWite(u3) + IsWite(currentPiece) == 1)
            {
                grids[u3].image.color = Red;
            }
        }
        int u4 = Get1DIndex(I +1, J +2);
        if (IsInBound(I + 1, J +2))
        {
            if (grids[u4].GetComponent<Image>().sprite == null)
                SetSprite(u4, yellowFrame);
            else if (grids[u4].GetComponent<Image>().sprite != null && IsWite(u4) + IsWite(currentPiece) == 1)
            {
                grids[u4].image.color = Red;
            }
        }
        int u5 = Get1DIndex(I - 1, J + 2);
        if (IsInBound(I - 1, J + 2))
        {
            if (grids[u5].GetComponent<Image>().sprite == null)
                SetSprite(u5, yellowFrame);
            else if (grids[u5].GetComponent<Image>().sprite != null && IsWite(u5) + IsWite(currentPiece) == 1)
            {
                grids[u5].image.color = Red;
            }
        }
        int u6 = Get1DIndex(I - 1, J - 2);
        if (IsInBound(I - 1, J - 2))
        {
            if (grids[u6].GetComponent<Image>().sprite == null)
                SetSprite(u6, yellowFrame);
            else if (grids[u6].GetComponent<Image>().sprite != null && IsWite(u6) + IsWite(currentPiece) == 1)
            {
                grids[u6].image.color = Red;
            }
        }
        int u7 = Get1DIndex(I +1, J - 2);
        if (IsInBound(I + 1, J - 2))
        {
            if (grids[u7].GetComponent<Image>().sprite == null)
                SetSprite(u7, yellowFrame);
            else if (grids[u7].GetComponent<Image>().sprite != null && IsWite(u7) + IsWite(currentPiece) == 1)
            {
                grids[u7].image.color = Red;
            }
        }
        
    }
    void QueenValidMoves(Sprite s, int I, int J)
    {
        for (int i = I + 1; i < 8; i++)
        {
            int u = Get1DIndex(i, J);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            int u = Get1DIndex(i, J);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;
        }
        for (int j = J + 1; j < 8; j++)
        {
            int u = Get1DIndex(I, j);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;

        }
        for (int j = J - 1; j >= 0; j--)
        {
            int u = Get1DIndex(I, j);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;

        }
        int k1 = I - J;
        int k2 = I + J;

        for (int i = I + 1; i < 8; i++)
        {
            bool Break = false;
            for (int j = J + 1; j < 8; j++)
            {

                if (i - j == k1)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null)
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                        grids[u].image.color = Red;
                        Break=true;
                    }
                    else
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            bool Break = false;
            for (int j = J - 1; j >= 0; j--)
            {

                if (i - j == k1)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null)
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                        grids[u].image.color = Red;
                        Break = true;
                    }
                    else
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        for (int i = I + 1; i < 8; i++)
        {
            bool Break = false;
            for (int j = J - 1; j >= 0; j--)
            {

                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null)
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                        grids[u].image.color = Red;
                        Break = true;
                    }
                    else
                        Break = true;

                }
            }
            if (Break)
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            bool Break = false;
            for (int j = J + 1; j < 8; j++)
            {

                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null)
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                        grids[u].image.color = Red;
                        Break = true;
                    }
                    else
                        Break = true;
                }
            }
            if (Break)
                break;
        }
    }
    void KingValidMoves(Sprite s, int I, int J)
    {
        int u = Get1DIndex(I+1, J);
        if (IsInBound(I + 1, J))
        {
            if (TwoKingClose(u))
            {
                if (grids[u].GetComponent<Image>().sprite == null)
                    SetSprite(u, yellowFrame);
                else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                {
                    grids[u].image.color = Red;
                }
            }
            
        }
         int u1 = Get1DIndex(I - 1, J);
        if (IsInBound(I - 1, J))
        {
            if (TwoKingClose(u1))
            {
                if (grids[u1].GetComponent<Image>().sprite == null)
                    SetSprite(u1, yellowFrame);
                else if (grids[u1].GetComponent<Image>().sprite != null && IsWite(u1) + IsWite(currentPiece) == 1)
                {
                    grids[u1].image.color = Red;
                }
            }
            
        }
        int u2 = Get1DIndex(I , J+1);
        if (IsInBound(I, J + 1))
        {
            if (TwoKingClose(u2))
            {
                if (grids[u2].GetComponent<Image>().sprite == null)
                    SetSprite(u2, yellowFrame);
                else if (grids[u2].GetComponent<Image>().sprite != null && IsWite(u2) + IsWite(currentPiece) == 1)
                {
                    grids[u2].image.color = Red;
                }
            }
            
        }
        int u3 = Get1DIndex(I , J-1);
        if (IsInBound(I, J - 1))
        {
            if (TwoKingClose(u3))
            {
                if (grids[u3].GetComponent<Image>().sprite == null)
                    SetSprite(u3, yellowFrame);
                else if (grids[u3].GetComponent<Image>().sprite != null && IsWite(u3) + IsWite(currentPiece) == 1)
                {
                    grids[u3].image.color = Red;
                }
            }
            
        }
        int u4 = Get1DIndex(I+1, J +1);
        if (IsInBound(I+1, J+1))
        {
            if (TwoKingClose(u4))
            {
                if (grids[u4].GetComponent<Image>().sprite == null)
                    SetSprite(u4, yellowFrame);
                else if (grids[u4].GetComponent<Image>().sprite != null && IsWite(u4) + IsWite(currentPiece) == 1)
                {
                    grids[u4].image.color = Red;
                }
            }
            
        }
        int u5 = Get1DIndex(I-1, J - 1);
        if (IsInBound(I-1, J - 1))
        {
            if (TwoKingClose(u5))
            {
                if (grids[u5].GetComponent<Image>().sprite == null)
                    SetSprite(u5, yellowFrame);
                else if (grids[u5].GetComponent<Image>().sprite != null && IsWite(u5) + IsWite(currentPiece) == 1)
                {
                    grids[u5].image.color = Red;
                }
            }
            
        }
        int u6 = Get1DIndex(I+1, J - 1);
        if (IsInBound(I+1, J - 1))
        {
            if (TwoKingClose(u6))
            {
                if (grids[u6].GetComponent<Image>().sprite == null)
                    SetSprite(u6, yellowFrame);
                else if (grids[u6].GetComponent<Image>().sprite != null && IsWite(u6) + IsWite(currentPiece) == 1)
                {
                    grids[u6].image.color = Red;
                }
            }
            
        }
        int u7 = Get1DIndex(I-1, J + 1);
        if (IsInBound(I-1, J + 1))
        {
            if (TwoKingClose(u7))
            {
                if (grids[u7].GetComponent<Image>().sprite == null)
                    SetSprite(u7, yellowFrame);
                else if (grids[u7].GetComponent<Image>().sprite != null && IsWite(u7) + IsWite(currentPiece) == 1)
                {
                    grids[u7].image.color = Red;
                }
            }
            
        }

    }
    void RookValidMoves(Sprite s, int I, int J)
    {
        for (int i = I + 1; i < 8; i++)
        {
             int u = Get1DIndex(i, J);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;               
        }
        for (int i = I - 1; i >=0; i--)
        {
            int u = Get1DIndex(i, J);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;
        }
        for (int j =J + 1; j < 8; j++)
        {
            int u = Get1DIndex(I, j);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;

        }
        for (int j = J - 1; j >=0; j--)
        {
            int u = Get1DIndex(I, j);
            if (grids[u].GetComponent<Image>().sprite == null)
                SetSprite(u, yellowFrame);
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
                break;
            }
            else
                break;

        }
    }
    void BishopValidMoves(Sprite s, int I, int J)
    {
        int k1 = I - J;
        int k2 = I + J;
 
        for (int i = I+1; i < 8; i++)
        {
            bool Break = false;
            for(int j=J+1; j < 8; j++)
            {
                
               if(i-j == k1 )
               {
                  int u =Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null )
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                            grids[u].image.color = Red;
                            Break = true;
                    }
                    else
                        Break = true;
               } 
            }
            if (Break)
                break;
        }
        for (int i = I - 1; i >=0; i--)
        {
            bool Break = false;
            for (int j = J - 1; j>=0; j--)
            {

                if (i - j == k1)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null)
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                            grids[u].image.color = Red;
                            Break = true;
                    }
                    else
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        for (int i = I+1; i < 8; i++)
        {
            bool Break = false;
            for (int j = J-1; j>=0; j--)
            {
                
                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null )
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                            grids[u].image.color = Red;
                            Break = true;
                    }
                    else
                        Break = true;
                    
                }
            }
            if (Break)
                break;
        }
        for (int i = I -1; i >=0; i--)
        {  bool Break= false;
            for (int j = J +1; j < 8; j++)
            {

                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite == null )
                        SetSprite(u, yellowFrame);
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
                    {
                            grids[u].image.color = Red;
                            Break = true;
                    }
                    else
                        Break = true;
                }
            }
            if (Break)
                break;
        }
    }
    void PawnValidMoves(Sprite s , int i , int j)
    {
        int r1 = 0;// go
        int r2=0;//go
        int r3 = 0;//hit
        int r4 = 0;//hit
        int r5 = 0;//hit
        
        if (pawnB == s)
        {
             r1 = i + 1;
            r2 = i + 2;
            r3 = i + 1;
            r4 = j + 1;
            r5 = j - 1;

        }
        else if(pawnW == s) 
        {
             r1 = i - 1;
             r2 = i - 2;
             r3 = i - 1;
            r4 = j + 1;
            r5 = j - 1;
             
        }
        int k1 = Get1DIndex(r1, j);
        if (IsInBound(r1, j))
        {
            if (grids[k1].GetComponent<Image>().sprite == null)
            {
                SetSprite(k1, yellowFrame);
            }
        }
        int k2 = Get1DIndex(r2, j);
        if (IsInBound(r2, j) && IsFirstMoveForPawn(s))
        {
            if (grids[k2].GetComponent<Image>().sprite == null && grids[k1].GetComponent<Image>().sprite == yellowFrame)
            {
                SetSprite(k2, yellowFrame);
            }
        }
        int u = Get1DIndex(r3, r4);
        if (IsInBound(r3, r4))
        {
            if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(currentPiece) == 1)
            {
                grids[u].image.color = Red;
            }
        }
        int u1 = Get1DIndex(r3,r5);
        if (IsInBound(r3, r5))
        {
            if (grids[u1].GetComponent<Image>().sprite != null && IsWite(u1) + IsWite(currentPiece) == 1)
            {
                grids[u1].image.color = Red;
            }
        }
    }
    void ClearSprite(int k)
    {
        grids[k].GetComponent<Image>().sprite = null;
        grids[k].image.color = noColor;
    }
    void SetSprite(int k , Sprite s)
    {
        grids[k].GetComponent<Image>().sprite = s;
        grids[k].image.color = color;

    }
    void MovePiece(int k)
    {  
            
        if (grids[currentPiece].GetComponent<Image>().sprite == pawnB && k >= 56 & k <= 63)  //convert pawn to queen
            grids[k].GetComponent<Image>().sprite = queenB;
        else if (grids[currentPiece].GetComponent<Image>().sprite == pawnW && k >= 0 & k <= 7)//convert pawn to queen
            grids[k].GetComponent<Image>().sprite = queenW;
        else
        grids[k].GetComponent<Image>().sprite = grids[currentPiece].GetComponent<Image>().sprite;
        ClearSprite(currentPiece);
            ClearValids();
        
    }
    void ClearValids()
    {
        for(int i=0 ; i<grids.Length; i++)
        {
            if (grids[i].GetComponent<Image>().sprite==yellowFrame)
            {
                grids[i].GetComponent<Image>().sprite = null;
                grids[i].image.color = noColor;
            }
            if (grids[i].image.color == Red)
            {
                grids[i].image.color = color;
            }

        }
    }
    int IsWite(int k)
    {
        if (grids[k].GetComponent<Image>().sprite == knightW ||
            grids[k].GetComponent<Image>().sprite == pawnW ||
            grids[k].GetComponent<Image>().sprite == queenW ||
            grids[k].GetComponent<Image>().sprite == kingW ||
            grids[k].GetComponent<Image>().sprite == rookW ||
            grids[k].GetComponent<Image>().sprite == bishopW)
            return 0;
        else if (grids[k].GetComponent<Image>().sprite == knightB ||
            grids[k].GetComponent<Image>().sprite == pawnB ||
            grids[k].GetComponent<Image>().sprite == queenB ||
            grids[k].GetComponent<Image>().sprite == kingB ||
            grids[k].GetComponent<Image>().sprite == rookB ||
            grids[k].GetComponent<Image>().sprite == bishopB)
            return 1; 
        else
            return 2;//other

    }
    bool IsInBound(int i , int j)
    {
        if ((i >= 0 && i <= 7) && (j >= 0 && j <= 7))
            return true;
        return false;
    }
    bool IsFirstMoveForPawn(Sprite s)
    {
        if (s == pawnW && currentPiece >= 48 && currentPiece <= 55)
            return true;
        if (s == pawnB && currentPiece >= 8 && currentPiece <= 15)
            return true;
        return false;

    }
    void Check()
    {
        int I = 0;
        int J = 0;
        int kW = 0;
        int kB = 0;
        kingBIsCheck = false;
        kingWIsCheck = false;
        for (int i=0; i< 64; i++)
        {
            Sprite s = grids[i].GetComponent<Image>().sprite;
            if (s == kingB)
                kB = i;
            if (s == kingW)
                kW = i;
        }
        for(int i=0; i< 64; i++)
        { Sprite s = grids[i].GetComponent<Image>().sprite;
           
            if (s == bishopB)
            {
                if (BishopCheck('W', i))
                {
                    CheckShow(kW);
                    kingWIsCheck = true;
                    print("checked by bishopB");
                }
            }
            if (s == rookB)
            {
                if (RookCheck('W', i))
                {
                    print("checked by rookB");
                    CheckShow(kW);
                    kingWIsCheck = true;
                }
            }
          
            if (s == queenB)
            {
                if (RookCheck('W', i) || BishopCheck('W', i))
                {
                    print("checked by queenWBi" + BishopCheck('W', i));
                    print("checked by queenWRo" + RookCheck('W', i));
                    CheckShow(kW);
                    kingWIsCheck = true;
                }
            }
            if (s == knightB)
            {
                if (KnightCheck('W', i))
                {
                    print("checked by knightB");
                    CheckShow(kW);
                    kingWIsCheck = true;
                }
            }
  
            if (s == pawnB)
            {
                if (PawnCheck('W', i))
                {
                    print("checked by pawnB");
                    CheckShow(kW);
                    kingWIsCheck = true;
                }
            }

            if (s == bishopW)
            {
                if (BishopCheck('B', i))
                {
                    print("checked by bishopW");
                    CheckShow(kB);
                    kingBIsCheck = true;
                }
                }
             if (s == rookW)
            {
                if (RookCheck('B', i))
                {
                    print("checked by rookW");
                    CheckShow(kB);
                    kingBIsCheck = true;
                }
            }
            if (s == queenW)
            {
                if (RookCheck('B', i) || BishopCheck('B', i))
                {
                  
                    CheckShow(kB);
                    kingBIsCheck = true;
                }
                }
            if (s == knightW)
            {
                if (KnightCheck('B', i))
                {
                    print("checked by knightW");
                    CheckShow(kB);
                    kingBIsCheck = true;
                }
                }
            if (s == pawnW)
            {
                if (PawnCheck('B', i))
                {
                    print("checked by pawnW");
                    CheckShow(kB);
                    kingBIsCheck = true;
                }
            }
            if (!kingBIsCheck)
                CheckClear(kB);
            if (!kingWIsCheck)
                CheckClear(kW);
        }
    }
    bool PawnCheck(char c , int k)
    {
        int I = 0;
        int J = 0;
        (I, J) = Get2DIndex(k);
        Sprite king = null;
        int r3 = 0;//hit
        int r4 = 0;//hit
        int r5 = 0;//hit
        if (c == 'B')
        {
            king = kingB;
            r3 = I - 1;
            r4 = J + 1;
            r5 = J - 1;
        }

        else if (c == 'W')
        {
            king = kingW;
            r3 = I + 1;
            r4 = I + 1;
            r5 = J - 1;
        }
        int u = Get1DIndex(r3, r4);
        if (IsInBound(r3, r4))
        {
            if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    print("UUUU");
                    return true;
                }
            }
        }
        int u1 = Get1DIndex(r3, r5);
        if (IsInBound(r3, r5))
        {
            if (grids[u1].GetComponent<Image>().sprite != null && IsWite(u1) + IsWite(k) == 1)
            {
                if (grids[u1].GetComponent<Image>().sprite == king)
                {
                    print("UUUU1");
                    return true;
                }
            }
        }
        return false;

    }
    bool KnightCheck(char c, int k)
    {
        int I = 0;
        int J = 0;
        (I, J) = Get2DIndex(k);
        Sprite king = null;

        if (c == 'B')
            king = kingB;
        else if (c == 'W')
            king = kingW;

        int u = Get1DIndex(I + 2, J - 1);
        if (IsInBound(I + 2, J - 1))
        {
            if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {   
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u1 = Get1DIndex(I + 2, J + 1);
        if (IsInBound(I + 2, J + 1))
        {
            if (grids[u1].GetComponent<Image>().sprite != null && IsWite(u1) + IsWite(k) == 1)
            {
                if (grids[u1].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u2 = Get1DIndex(I - 2, J - 1);
        if (IsInBound(I - 2, J - 1))
        {   
            if (grids[u2].GetComponent<Image>().sprite != null && IsWite(u2) + IsWite(k) == 1)
            {
                if (grids[u2].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u3 = Get1DIndex(I - 2, J + 1);
        if (IsInBound(I - 2, J + 1))
        {
            if (grids[u3].GetComponent<Image>().sprite != null && IsWite(u3) + IsWite(k) == 1)
            {
                if (grids[u3].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u4 = Get1DIndex(I + 1, J + 2);
        if (IsInBound(I + 1, J + 2))
        {
            if (grids[u4].GetComponent<Image>().sprite != null && IsWite(u4) + IsWite(k) == 1)
            {
                if (grids[u4].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u5 = Get1DIndex(I - 1, J + 2);
        if (IsInBound(I - 1, J + 2))
        {
            if (grids[u5].GetComponent<Image>().sprite != null && IsWite(u5) + IsWite(k) == 1)
            {
                if (grids[u5].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u6 = Get1DIndex(I - 1, J - 2);
        if (IsInBound(I - 1, J - 2))
        {
            if (grids[u6].GetComponent<Image>().sprite != null && IsWite(u6) + IsWite(k) == 1)
            {
                if (grids[u6].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
        int u7 = Get1DIndex(I + 1, J - 2);
        if (IsInBound(I + 1, J - 2))
        {
            if (grids[u7].GetComponent<Image>().sprite != null && IsWite(u7) + IsWite(k) == 1)
            {
                if (grids[u7].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
            }
        }
   
        return false;
    }
    bool BishopCheck(char c, int k)
    {
        int I = 0;
        int J = 0;
        (I, J) = Get2DIndex(k);
        Sprite king = null;

        if (c == 'B')
            king = kingB;
        else if (c == 'W')
            king = kingW;
        int k1 = I - J;
        int k2 = I + J;

        for (int i = I + 1; i < 8; i++)
        {
            bool Break = false;
            for (int j = J + 1; j < 8; j++)
            {

                if (i - j == k1)
                {
                    int u = Get1DIndex(i, j);
                     if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
                    {
                       
                        if (grids[u].GetComponent<Image>().sprite == king)
                        {
                          
                            return true;
                        }
                        Break = true;
                    }
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) ==IsWite(k) )
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            bool Break = false;
            for (int j = J - 1; j >= 0; j--)
            {
                if (i - j == k1)
                {
                    int u = Get1DIndex(i, j);
                   if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
                    {
                    
                        if (grids[u].GetComponent<Image>().sprite == king)
                        {
                     
                            return true;
                        }
                        Break = true;
                    }
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u)== IsWite(k))
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        for (int i = I + 1; i < 8; i++)
        {
            bool Break = false;
            for (int j = J - 1; j >= 0; j--)
            {

                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                    if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
                    {
                     
                        if (grids[u].GetComponent<Image>().sprite == king)
                        {
                          
                            return true;
                        }
                        Break = true;
                    }
                    else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) ==IsWite(k))
                        Break = true;

                }
            }
            if (Break)
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            bool Break = false;
            for (int j = J + 1; j < 8; j++)
            {
                if (i + j == k2)
                {
                    int u = Get1DIndex(i, j);
                     if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
                    {
                       
                        if (grids[u].GetComponent<Image>().sprite == king)
                        {
                           
                            return true;
                        }
                        Break = true;
                    }
                      else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u)== IsWite(k))
                        Break = true;
                }
            }
            if (Break)
                break;
        }
        return false;

    }
    bool RookCheck(char c, int k)
    {  
        int I = 0;
        int J = 0;
        (I, J) = Get2DIndex(k);
        Sprite king = null;

        if (c == 'B')
            king = kingB;
        else if (c == 'W')
            king = kingW;

        for (int i = I + 1; i < 8; i++)
        {
            int u = Get1DIndex(i, J);
             if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
                break;
            }
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) == IsWite(k))
                break;
        }
        for (int i = I - 1; i >= 0; i--)
        {
            int u = Get1DIndex(i, J);
             if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
                break;
            }
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) == IsWite(k) )
                break;
        }
        for (int j = J + 1; j < 8; j++)
        {
            int u = Get1DIndex(I, j);
             if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
                break;
            }
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) == IsWite(k) )
                break;

        }
        for (int j = J - 1; j >= 0; j--)
        {
            int u = Get1DIndex(I, j);
             if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) + IsWite(k) == 1)
            {
                if (grids[u].GetComponent<Image>().sprite == king)
                {
                    return true;
                }
                break;
            }
            else if (grids[u].GetComponent<Image>().sprite != null && IsWite(u) == IsWite(k) )
                break;

        }
        return false;

    }
    void CheckShow(int i)
    {
        grids[i].image.color = Purple;//chech is happen
    }
    void CheckClear(int i)
    {
        grids[i].image.color = color;//chech is happen
    }
    bool TwoKingClose(int k)//two kings cannot be close togheter.
    {  Sprite king = null;
        int i = 0;
        int j = 0;
        (i, j) = Get2DIndex(k);
        if (grids[currentPiece].GetComponent<Image>().sprite == kingB)
            king = kingW;
        else if (grids[currentPiece].GetComponent<Image>().sprite == kingW)
            king = kingB;
        int u  = Get1DIndex(i + 1, j);
        int u1 = Get1DIndex(i-1 , j);
        int u2 = Get1DIndex(i , j+1);
        int u3 = Get1DIndex(i + 1, j-1);
        int u4 = Get1DIndex(i +1, j+1);
        int u5 = Get1DIndex(i -1, j-1);
        int u6 = Get1DIndex(i + 1, j-1);
        int u7 = Get1DIndex(i -1 , j+1);
        if ( ( !IsInBound(i + 1, j) || (IsInBound(i+1 ,j) && grids[u].GetComponent<Image>().sprite!=king)) &&
            (!IsInBound(i - 1, j) || (IsInBound(i - 1, j) && grids[u1].GetComponent<Image>().sprite != king)) &&
             (!IsInBound(i, j + 1) || (IsInBound(i, j + 1) && grids[u2].GetComponent<Image>().sprite != king)) &&
           (!IsInBound(i + 1, j - 1) || (IsInBound(i + 1, j - 1) && grids[u3].GetComponent<Image>().sprite != king)) &&
            (!IsInBound(i + 1, j + 1) ||(IsInBound(i + 1, j + 1) && grids[u4].GetComponent<Image>().sprite != king)) &&
           (!IsInBound(i - 1, j - 1) || (IsInBound(i - 1, j - 1) && grids[u5].GetComponent<Image>().sprite != king)) &&
           ( !IsInBound(i + 1, j - 1) || (IsInBound(i + 1, j - 1) && grids[u6].GetComponent<Image>().sprite != king)) &&
           (!IsInBound(i - 1, j + 1) || (IsInBound(i - 1, j + 1) && grids[u7].GetComponent<Image>().sprite != king)) 
            )
            return true;
        else 
            return false;
    }
    void GameOver()
    {
        if (kingBIsCheck && ChessTurn.whoturn == 1 && ChessTurn.T <= 1)
        {
            GameOverCanvas.SetActive(true);
            GameIsOver= true;
        }
        if (kingWIsCheck && ChessTurn.whoturn == 0 && ChessTurn.T <= 1)
        {
            GameOverCanvas.SetActive(true);
            GameIsOver = true;
        }
    }
}
