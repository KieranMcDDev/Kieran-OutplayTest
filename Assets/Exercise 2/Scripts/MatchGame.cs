using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MonoBehaviour
{
    Board board;

    [SerializeField]
    int BoardSizeX, BoardSizeY;

    //Prefab for Jewels
    [SerializeField]
    GameObject JewelObject;

    //Random Seed Value
    [SerializeField]
    int seed;
    //Handles spawning of the board
    private void Awake()
    {
        Random.InitState(seed);

        board = new Board(BoardSizeX, BoardSizeY);

        for (int y = 0; y < BoardSizeY; y++)
        {
            for (int x = 0; x < BoardSizeX; x++)
            {
                //Spawning Jewels
                GameObject jewel = Instantiate<GameObject>(JewelObject, transform);
                jewel.transform.SetLocalPositionAndRotation(new Vector3(x - (float)BoardSizeX/2f + 0.5f, y - (float)BoardSizeY/2f + 0.5f,0), Quaternion.identity);

                //Sets the colour of the object
                Color color = new Color(0,0,0,0);
                switch (board.GetJewel(x, y))
                {
                    case Board.JewelKind.Red:
                        color = Color.red;
                        break;
                    case Board.JewelKind.Blue:
                        color = Color.blue;
                        break;
                    case Board.JewelKind.Orange:
                        color = new Color(255f/255f,144/255f,0);
                        break;
                    case Board.JewelKind.Violet:
                        color = Color.magenta;
                        break;
                    case Board.JewelKind.Yellow:
                        color = Color.yellow;
                        break;
                    case Board.JewelKind.Green:
                        color = Color.green;
                        break;
                    case Board.JewelKind.Indigo:
                        color = new Color(75f / 255f, 0, 130f / 255f);
                        break;
                }
                
                jewel.GetComponent<SpriteRenderer>().color = color;
            }
        }

        board.CalculateBestMoveForBoard();
    }
}
