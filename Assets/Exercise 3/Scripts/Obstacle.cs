using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    //Handles positioning of the object when spawned
    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
    }
}
