using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MonoBehaviour
{
    Board board;

    [SerializeField]
    int BoardSizeX, BoardSizeY;
    [SerializeField]
    GameObject JewelObject;
    private void Awake()
    {
        board = new Board(BoardSizeX, BoardSizeY);

        for (int y = 0; y < BoardSizeY; y++)
        {
            for (int x = 0; x < BoardSizeX; x++)
            {
                GameObject jewel = Instantiate<GameObject>(JewelObject, transform);
                jewel.transform.SetLocalPositionAndRotation(new Vector3(x,y,0), Quaternion.identity);

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
