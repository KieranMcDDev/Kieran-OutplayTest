using UnityEditor;
using UnityEngine;


public class MainObject : MonoBehaviour
{
    //Transforms for the Main Object to go towards
    //The reason transforms are used is because it would make it easier fo rthe designer to move and see where the point is in the scene
    [SerializeField]
    Transform[] points = new Transform[3];

    int index;

    [SerializeField]
    float speed;

    //Particle and Sound effect object
    [SerializeField]
    GameObject DeathObject;

    private void Start()
    {
        index = 0;
    }
    public void Update()
    {
        //Checks if the mainobject is still going towards a point
        if(index < points.Length)
        {
            MoveTo();
        }
        else{
            OnDeath();
        }
    }

    //Move to current point
    private void MoveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[index].position) == 0)
        {
            index++;
        }

    }

    //Used when the player reaches the endpoint or collides with a obstacle
    void OnDeath()
    {
        DeathObject.SetActive(true);
        DeathObject.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //Checks for collision with obstacle
        if (other.tag == "Obstacle")
        {
            OnDeath();
        }
    }

#if UNITY_EDITOR
    //Draws lines and spheres to represent the path and points
    private void OnDrawGizmos()
    {
        if (points.Length < 1) return;
        if (points[0] != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, points[0].position);
        }

        for(int i = 0;i < points.Length-1; i++)
        {
            if (points[i] != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(points[i].position, 0.2f);

                if (points[i + 1])
                {
                    Gizmos.DrawSphere(points[i + 1].position, 0.2f);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
                }
            }
        }

        
    }
#endif
}
