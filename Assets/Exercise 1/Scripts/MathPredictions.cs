using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathPredictions
{
    public static bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition)
    {
        //Check if ball reaches height
        float maxHeight = ((v.y * v.y) / -G) * 0.5f + p.y;
        Debug.Log("Max Height: " + maxHeight);
        if (maxHeight < h) return false;

        //Find Time Takes To Reach Height


        //Use time to find how far the ball goes in the X Axis

        //Find where the ball lies within the boundary

        return false;
    }
}
