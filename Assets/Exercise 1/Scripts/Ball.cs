using UnityEngine;

//Tests functionality for CalculateXPosition
public class Ball : MonoBehaviour
{
    //Test Variables
    [SerializeField]
    Vector2 Velocity, Position;
    [SerializeField]
    float Gravity, Height, XPos, Width;

    public void Start()
    {       
        MathPredictions.TryCalculateXPositionAtHeight(Height, Position, Velocity, Gravity, Width, ref XPos);
    }

   
}


