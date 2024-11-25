using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
    }
}
