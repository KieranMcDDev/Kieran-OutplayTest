public class Board
{
    enum JewelKind
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

    enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    struct Move
    {
        public int x;
        public int y;
        public MoveDirection direction;
    }
    int GetWidth()
    {
        return 0;
    }
    int GetHeight()
    {
        return 0;
    }
    JewelKind GetJewel(int x, int y)
    {
        return JewelKind.Empty;
    }
    void SetJewel(int x, int y, JewelKind kind)
    {

    }
    Move CalculateBestMoveForBoard()
    {
        Move bestMove = new Move();
        int bestScore = 2;
        //Loop through grid
        for(int y = 0; y < GetHeight(); y++)
        {
            for(int x = y%2; x < GetWidth(); x++)
            {
                for(int z = 0; z < 4; z++)
                {
                    Move move = new Move();
                    move.x = x; move.y = y; move.direction = (MoveDirection)z;
                    int moveScore = CheckMove(move);

                    if (moveScore > bestScore)
                    {
                        bestScore = moveScore;
                        bestMove = move;
                    }
                }
            }
        }
        //Check for match

        //Check if match is greater than previous match

        //Check if there was any matches if not shuffle

        //Return best move
        return new Move();
    }

    void Shuffle()
    {

    }

    int CheckMove(Move move)
    {
        //Checks if it is a valid move
        if (move.x == 0 && move.direction == MoveDirection.Left) return 0;
        if (move.x == GetWidth()-1 && move.direction == MoveDirection.Right) return 0;
        if (move.y == 0 && move.direction == MoveDirection.Down) return 0;
        if (move.y == GetHeight()-1 && move.direction == MoveDirection.Up) return 0;
        

        return 0;
    }


    int CheckMatchScore(int x, int y, JewelKind jewel)
    {
        int verticalScore = 0;
        int horizontalScore = 0;
        int finalScore = 0;

        int tempVerticalScore = 0;
        //Checks for vertical matches
        for (int i = 2; i > -3; i--)
        {
            //Checks if the current y pos is within the boundary
            if (y + i > GetHeight() - 1 || y + i < 0)
            {
                tempVerticalScore = 0;
                continue;
            }

            //Checks if the current grid pos is the appropriate jewel
            if (GetJewel(x, y + i) == jewel)
            {
                tempVerticalScore++;
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
            //Checks if the current x pos is within the boundary
            if (x + i > GetWidth() - 1 || x + i < 0)
            {
                tempHorizontalScore = 0;
                continue;
            }

            //Checks if the current grid pos is the appropriate jewel
            if (GetJewel(x + i, y) == jewel)
            {
                tempHorizontalScore++;
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
