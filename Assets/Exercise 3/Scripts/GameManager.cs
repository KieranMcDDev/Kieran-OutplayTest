using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int totalObstacles = 100;

    [SerializeField]
    float maxX, minX, maxY, minY, maxZ, minZ;

    [SerializeField]
    GameObject ObstaclePrefab;
    private void Awake()
    {
        for (int i = 0; i < totalObstacles; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            GameObject o = Instantiate<GameObject>(ObstaclePrefab);
            o.GetComponent<Obstacle>().Spawn(position);
        }
    }

#if UNITY_EDITOR
    //Display the boundaries of the obstacles spawn
    private void OnDrawGizmos()
    {

        Gizmos.DrawLine(new Vector3(minX, maxY, minZ), new Vector3(maxX, maxY, minZ));
        Gizmos.DrawLine(new Vector3(minX, maxY, minZ), new Vector3(maxX, maxY, minZ));
        Gizmos.DrawLine(new Vector3(minX, minY, maxZ), new Vector3(maxX, minY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, minY, maxZ), new Vector3(maxX, minY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, minY, minZ), new Vector3(minX, maxY, minZ));
        Gizmos.DrawLine(new Vector3(minX, minY, maxZ), new Vector3(minX, maxY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, minY, minZ), new Vector3(minX, minY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, maxY, minZ), new Vector3(minX, maxY, maxZ));
        Gizmos.DrawLine(new Vector3(maxX, minY, minZ), new Vector3(maxX, maxY, minZ));
        Gizmos.DrawLine(new Vector3(maxX, minY, maxZ), new Vector3(maxX, maxY, maxZ));
        Gizmos.DrawLine(new Vector3(maxX, minY, minZ), new Vector3(maxX, minY, maxZ));
        Gizmos.DrawLine(new Vector3(maxX, maxY, minZ), new Vector3(maxX, maxY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, maxY, maxZ), new Vector3(maxX, maxY, maxZ));
        Gizmos.DrawLine(new Vector3(minX, minY, minZ), new Vector3(maxX, minY, minZ));
    }
#endif
}


#if UNITY_EDITOR
[CustomEditor(typeof(GameManager))]
[CanEditMultipleObjects]
public class GameManagerEditor : Editor
{
    SerializedProperty minX, maxX, minY, maxY, minZ, maxZ;

    void OnEnable()
    {
        minX = serializedObject.FindProperty("minX");
        maxX = serializedObject.FindProperty("maxX");
        minY = serializedObject.FindProperty("minY");
        maxY = serializedObject.FindProperty("maxY");
        minZ = serializedObject.FindProperty("minZ");
        maxZ = serializedObject.FindProperty("maxZ");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        DrawDefaultInspector();


        //Makes sure that the min is greater than the max values for the appropriate axis
        if (minX.floatValue > maxX.floatValue) minX.floatValue = maxX.floatValue;
        if (maxY.floatValue > maxY.floatValue) maxY.floatValue = maxY.floatValue;
        if (minZ.floatValue > minZ.floatValue) minZ.floatValue = maxZ.floatValue;

        serializedObject.ApplyModifiedProperties();

    }
}
#endif
