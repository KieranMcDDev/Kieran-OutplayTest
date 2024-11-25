using UnityEditor;
using UnityEngine;


public class MainObject : MonoBehaviour
{

    [SerializeField]
    Transform[] points = new Transform[3];

    [SerializeField]
    int index;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject DeathObject;

    private void Start()
    {
        index = 0;
    }
    public void Update()
    {
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

    void OnDeath()
    {
        DeathObject.SetActive(true);
        DeathObject.transform.position = transform.position;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");

        if (other.tag == "Obstacle")
        {
            OnDeath();
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Draw a yellow cube at the transform position

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
