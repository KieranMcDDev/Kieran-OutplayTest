using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Loop through grid

        //Check for match

        //Check if match is greater than previous match

        //Check if there was any matches if not shuffle

        //Return best move
        return new Move();
    }
}
