using System.Drawing;
using UnityEngine;

public class Board
{
    //Default Board
    public Board()
    {      
        board = new JewelKind[10,10];

        BuildBoard(10,10);

        CalculateBestMoveForBoard();
    }
    
    //Custom Board
    public Board(int sizeX, int sizeY)
    {
        //Sets board size to a valid amount if too low
        if (sizeX < 4) sizeX = 4;
        if (sizeY < 4) sizeY = 4;

        board = new JewelKind[sizeX, sizeY];

        BuildBoard(sizeX, sizeY);

        CalculateBestMoveForBoard();
    }

    //Sets up the board
    void BuildBoard(int sizeX,int sizeY)
    {
        board = new JewelKind[sizeX, sizeY];

        for (int y = 0; y < GetHeight(); y++)
        {
            for (int x = 0; x < GetWidth(); x++)
            {
                SetJewel(x, y, (JewelKind)Random.Range(1, 8));
                //Makes sure that the jewel placed doesnt already have a match
                while (CheckMatchScore(x, y, GetJewel(x, y), x, y, GetJewel(x, y)) > 0)
                {
                    SetJewel(x, y, (JewelKind)Random.Range(1, 8));
                }
            }
        }
    }

    public enum JewelKind
    {
        Empty,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public struct Move
    {
        public int x;
        public int y;
        public MoveDirection direction;
    }

    //Stores the jewels for the board
    JewelKind[,] board; 

    //Width of the board
    int GetWidth()
    {
        return board.GetLength(0);
    }

    //Height of the board
    int GetHeight()
    {
        return board.GetLength(1);
    }

    public JewelKind GetJewel(int x, int y)
    {
        //Checks if its a valid jewel
        if (x < 0 || x > GetWidth() - 1 || y < 0 || y > GetHeight() - 1) return JewelKind.Empty;
        return board[x,y];
    }
    void SetJewel(int x, int y, JewelKind kind)
    {
        //Checks if its a valid jewel
        if (x < 0 || x > GetWidth() - 1 || y < 0 || y > GetHeight() - 1) return;
        board[x,y] = kind;
    }
    public Move CalculateBestMoveForBoard()
    {
        Move bestMove = new Move();
        int bestScore = 2;

        while(bestScore == 2)
        {
            //Loop through grid in a checker board pattern
            for (int y = 0; y < GetHeight(); y++)
            {
                for (int x = y % 2; x < GetWidth(); x += 2)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        Move move = new Move();
                        move.x = x; move.y = y; move.direction = (MoveDirection)z;
                        //Checks to see what the move score is 
                        int moveScore = CheckMove(move);

                        //Checks if the move score is better than the best score
                        if (moveScore > bestScore)
                        {
                            bestScore = moveScore;
                            bestMove = move;
                        }
                    }
                }
            }

            //Check if there was any matches if not shuffle
            if (bestScore == 2)
            {
                Debug.Log("No Available Moves Shuffle");
                Shuffle();              
            }
        }

        Debug.Log("Best Move: Pos: " + bestMove.x + " : " + bestMove.y + " Direction: " + bestMove.direction);
        Debug.Log("Highest Score: " + bestScore);



        //Return best move
        return bestMove;
    }

    //Shuffle Currently Replaces the board but would be changed to move around the jewels instead
    void Shuffle()
    {
        BuildBoard(GetWidth(), GetHeight());
    }

    int CheckMove(Move move)
    {
        //Checks if it is a valid move
        if (move.x == 0 && move.direction == MoveDirection.Left) return 0;
        if (move.x == GetWidth()-1 && move.direction == MoveDirection.Right) return 0;
        if (move.y == 0 && move.direction == MoveDirection.Down) return 0;
        if (move.y == GetHeight()-1 && move.direction == MoveDirection.Up) return 0;

        int finalScore = 0;
        
        //Check move direction to check for matches
        switch (move.direction)
        {
            case MoveDirection.Left:
                //Check score for jewel moving to the left
                finalScore += CheckMatchScore(move.x-1, move.y, GetJewel(move.x, move.y), move.x, move.y, GetJewel(move.x - 1, move.y));

                //This is to check if the same jewel was switched with each other
                if (GetJewel(move.x, move.y) == GetJewel(move.x - 1, move.y)) break;

                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x-1, move.y), move.x - 1, move.y, GetJewel(move.x, move.y));
                break;

            case MoveDirection.Right:
                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x + 1, move.y, GetJewel(move.x, move.y), move.x, move.y, GetJewel(move.x + 1, move.y));

                //This is to check if the same jewel was switched with each other
                if (GetJewel(move.x, move.y) == GetJewel(move.x + 1, move.y)) break;

                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x + 1, move.y), move.x + 1, move.y, GetJewel(move.x, move.y));
                break;

            case MoveDirection.Down:
                //Check score for jewel moving Down
                finalScore += CheckMatchScore(move.x, move.y - 1, GetJewel(move.x, move.y), move.x, move.y, GetJewel(move.x, move.y - 1));

                //This is to check if the same jewel was switched with each other
                if (GetJewel(move.x, move.y) == GetJewel(move.x, move.y - 1)) break;

                //Check score for jewel moving Up
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x, move.y - 1), move.x, move.y - 1, GetJewel(move.x, move.y));
                break;

            case MoveDirection.Up:
                //Check score for jewel moving Up
                finalScore += CheckMatchScore(move.x, move.y + 1, GetJewel(move.x, move.y), move.x, move.y, GetJewel(move.x, move.y + 1));

                //This is to check if the same jewel was switched with each other
                if (GetJewel(move.x, move.y) == GetJewel(move.x, move.y + 1)) break;

                //Check score for jewel moving Down
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x, move.y + 1), move.x, move.y + 1, GetJewel(move.x, move.y));
                break;
        }

        return finalScore;
    }


    int CheckMatchScore(int x, int y, JewelKind jewel, int fromX, int fromY, JewelKind switchedJewel)
    {
        int verticalScore = 0;
        int horizontalScore = 0;
        int finalScore = 0;

        int tempVerticalScore = 0;
        //Checks for vertical matches
        for (int i = 2; i > -3; i--)
        {
            //Since we know that the center jewel is the jewel that is being searched add 1 to the vertical score
            if (i == 0)
            {
                tempVerticalScore++;
                continue;
            }
           
            //Checks if the current y pos is within the boundary
            if (y + i > GetHeight() - 1 || y + i < 0)
            {
                tempVerticalScore = 0;
                continue;
            }

            //Check the switched tile
            if (x == fromX && y + i == fromY)
            {
                if(jewel == switchedJewel)
                {
                    tempVerticalScore++;
                }
                else
                {
                    tempVerticalScore = 0;
                }
            }
            //Checks if the current grid pos is the appropriate jewel
            else if (GetJewel(x, y + i) == jewel)
            {
                tempVerticalScore++;
            }
            else
            {
                tempVerticalScore = 0;
            }

            //Checks to see if the temp score is a match and applies it to the final vertical score
            if (tempVerticalScore > verticalScore && tempVerticalScore > 2)
            {

                verticalScore = tempVerticalScore;
            }
        }

        int tempHorizontalScore = 0;
        for (int i = 2; i > -3; i--)
        {
            //Since we know that the center jewel is the jewel that is being searched add 1 to the vertical score
            if (i == 0)
            {
                tempHorizontalScore++;
                continue;
            }

            //Checks if the current x pos is within the boundary
            if (x + i > GetWidth() - 1 || x + i < 0)
            {
                tempHorizontalScore = 0;
                continue;
            }

            //Check the switched tile
            if (x + i == fromX && y== fromY)
            {
                if (jewel == switchedJewel)
                {

                    tempHorizontalScore++;
                }
                else
                {
                    tempHorizontalScore = 0;

                }
            }
            //Checks if the current grid pos is the appropriate jewel
            else if (GetJewel(x + i, y) == jewel)
            {
                tempHorizontalScore++;
            }
            else
            {
                tempHorizontalScore = 0;
            }

            //Checks to see if the temp score is a match and applies it to the final horzontal score
            if (tempHorizontalScore > horizontalScore && tempHorizontalScore > 2)
            {
                horizontalScore = tempHorizontalScore;
            }
        }
       
        //Combines the vertical and horizontal score
        finalScore = verticalScore + horizontalScore;

        return finalScore;
    }  
}
