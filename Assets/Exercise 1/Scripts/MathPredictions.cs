using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathPredictions
{
    //Current implementation only handles gravity going downwards
    public static bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition)
    {
        
        float displacement = h - p.y;
        //checks if the position of the ball already at the predicted height
        if(displacement == 0)
        {
            Debug.LogWarning("Ball was at the position of the height to reach");
            xPosition = p.x;
            return true;
        }


        //Checks if the ball is going downwards and the height is above the ball
        if (v.y <= 0 && h > p.y)
        {
            Debug.LogWarning("Ball went downwards while height was set above");
            return false;
        }


        //Check if ball reaches height
        float maxHeight = ((v.y * v.y) / -G) * 0.5f + p.y;
        Debug.Log("Max Height: " + maxHeight);
        if (maxHeight < h)
        {
            Debug.LogWarning("Ball was unable to reach the height set");
            return false;
        }
        //Find Time Takes To Reach Heights
        Debug.Log("Displacement: " + displacement + "Height: " + h + "Velocity Y: " + v.y + "Gravity: " + G);
        float timeOne = 0f, timeTwo = 0f;

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
        float distanceX = 0f;
        //checks whether the first time or second time should be used based on the position and velocity of the player
        if (p.y < h && v.y > 0)
        {
            distanceX = v.x * timeOne;            
            Debug.Log("Distance X: " + distanceX);
        }
        else
        {
            distanceX = v.x * timeTwo;
            Debug.Log("Distance X: " + distanceX);
        }

        //Find where the ball lies within the boundary
        //Checks if the ball went right or left
        if (distanceX > 0)
        {
            //Removes the distance from the player to the wall
            float temp = distanceX - (w - p.x);
            //checks if the ball reaches the wall
            if(temp < 0)
            {
                xPosition = p.x + distanceX;
                Debug.Log("Position X: " + xPosition);
            }
            else
            {
                //checks how many times the ball hits the wall
                float temptwo = temp / w;
                Debug.Log("Wall Bounces: " +  (int)temptwo);
                float totalLoops = (int)temptwo;
                //Calculates the position of the ball within the boundary
                xPosition = Mathf.Abs((w * (totalLoops % 2)) - (temp - (totalLoops * w)));
                Debug.Log("Position X: " + xPosition);
            }
        }
        else
        {
            //Removes the distance from the player to the wall
            float temp = Mathf.Abs(distanceX) - p.x;
            //checks if the ball reaches the wall
            if (temp < 0)
            {
                xPosition = p.x - Mathf.Abs(distanceX);
                Debug.Log("Position X: " + xPosition);
            }
            else
            {

                //checks how many times the ball hits the wall
                float temptwo = temp / w;
                Debug.Log("Wall Bounces: " + (int)temptwo);
                float totalLoops = (int)temptwo;
                //Calculates the position of the ball within the boundary 
                xPosition = Mathf.Abs((w * ((totalLoops) % 2)) - (temp - (totalLoops * w)));
                Debug.Log("Position X: " + xPosition);
            }
        }

       

        return true;
    }
}
