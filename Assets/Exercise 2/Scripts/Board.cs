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

        //Loop through grid in a checker board pattern
        for(int y = 0; y < GetHeight(); y++)
        {
            for(int x = y%2; x < GetWidth(); x++)
            {
                for(int z = 0; z < 4; z++)
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
        if(bestScore == 2)
        {
            Shuffle();
        }

        //Return best move
        return bestMove;
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

        int finalScore = 0;
        
        //Check move direction to check for matches
        switch (move.direction)
        {
            case MoveDirection.Left:
                //Check score for jewel moving to the left
                finalScore += CheckMatchScore(move.x-1, move.y, GetJewel(move.x, move.y));
                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x-1, move.y));
                break;
            case MoveDirection.Right:
                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x + 1, move.y, GetJewel(move.x, move.y));
                //Check score for jewel moving to the right
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x + 1, move.y));
                break;
            case MoveDirection.Down:
                //Check score for jewel moving Down
                finalScore += CheckMatchScore(move.x, move.y - 1, GetJewel(move.x, move.y));
                //Check score for jewel moving Up
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x, move.y - 1));
                break;
            case MoveDirection.Up:
                //Check score for jewel moving Up
                finalScore += CheckMatchScore(move.x, move.y + 1, GetJewel(move.x, move.y));
                //Check score for jewel moving Down
                finalScore += CheckMatchScore(move.x, move.y, GetJewel(move.x, move.y + 1));
                break;
        }

        return finalScore;
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
