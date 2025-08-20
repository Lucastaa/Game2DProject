using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform target;
    public Transform PointA;
    public Transform PointB;
    private Rigidbody2D rb;
    public bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = PointA;
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
        if (target == PointA)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (target == PointB)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Collision detected with:Ground ");
        }
    }
}
