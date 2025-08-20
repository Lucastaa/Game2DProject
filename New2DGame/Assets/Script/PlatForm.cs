using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform target;
    public Transform PointA;
    public Transform PointB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var distanceToTarget = Vector3.Distance(transform.position, target.position);
        Debug.Log("Distance to target: " + distanceToTarget);
        if (distanceToTarget == 0)
        {
            SwitchTarget();
            Debug.Log("Reached target PointA!");
        }
    }
    void SwitchTarget()
    {
        if (target == PointA)
        {
            target = PointB;
            Debug.Log("Switching target to PointB");
        }
        else
        {
            target = PointA;
            Debug.Log("Switching target to PointA");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected!");
            collision.transform.SetParent(transform);
            //Invoke(nameof(DropPlatform), 2.0f);
        }
    }
    void DropPlatform()
    {
        Debug.Log("Dropping platform!");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player ended!");
            collision.transform.SetParent(null);
        }
    }

}
