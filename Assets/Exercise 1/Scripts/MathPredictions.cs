using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathPredictions
{
    public static bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition)
    {
        //Find Time Takes To Reach Height
        float displacement = h - p.y;
        if(displacement == 0)
        {
            xPosition = p.x;
            return true;
        }

        if (v.y <= 0 && h > p.y) return false;

        //Check if ball reaches height
        float maxHeight = ((v.y * v.y) / -G) * 0.5f + p.y;
        Debug.Log("Max Height: " + maxHeight);
        if (maxHeight < h) return false;

       
        Debug.Log("Displacement: " + displacement + "Height: " + h + "Velocity Y: " + v.y + "Gravity: " + G);
        float timeOne = 0, timeTwo = 0;

        //Utlising the equation s = ut - 1/2gt² rearranging it for -1/2gt² + ut - s = 0
        //to then use the quadratic formula to obtain the time it takes to reach the height
        //s = Displacement
        //u = Initial Velocity
        //t = Time
        //g = gravity

        timeOne = -v.y + Mathf.Sqrt(Mathf.Abs(Mathf.Pow(v.y,2f) - (2f * G * -displacement)));
        timeOne /= (G);

        timeTwo  = -v.y - Mathf.Sqrt(Mathf.Abs(Mathf.Pow(v.y, 2f) - (2f * G * -displacement)));
        timeTwo /= (G);
        Debug.Log("Time One: " + timeOne + " Time Two: " + timeTwo);



        //Use time to find how far the ball goes in the X Axis

        //Find where the ball lies within the boundary

        return false;
    }
}
