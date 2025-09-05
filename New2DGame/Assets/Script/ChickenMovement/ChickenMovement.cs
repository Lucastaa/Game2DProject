using UnityEditor;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public float radiusStart = 1f;
    public float expandSpeed = 0.1f;
    public float rotateSpeed = 5f;
    public bool clockwise = true;

    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * rotateSpeed;
        float r = radiusStart + expandSpeed * t;
        float x = r * Mathf.Cos(clockwise ? -t : t);
        float y = r * Mathf.Sin(clockwise ? -t : t);
        transform.position = new Vector2(x, y + 3);
    }
    //public float speed = 2.0f;
    //public Transform target;
    //public Transform PointA;
    //public Transform PointB;
    //private Rigidbody2D rb;
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    target = PointB;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //    var distanceToTarget = Vector3.Distance(transform.position, target.position);
    //    Debug.Log("Distance to target: " + distanceToTarget);
    //    if (distanceToTarget == 0)
    //    {
    //        SwitchTarget();
    //    }
    //    if (target == PointA)
    //    {
    //        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    //    }
    //    else if (target == PointB)
    //    {
    //        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    //    }
    //}
    //void SwitchTarget()
    //{
    //    if (target == PointA)
    //    {
    //        target = PointB;
    //        Debug.Log("Switching target to PointB");
    //    }
    //    else
    //    {
    //        target = PointA;
    //        Debug.Log("Switching target to PointA");
    //    }
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            var Legs = Instantiate(Resources.Load<GameObject>("Leg"), transform.position, Quaternion.identity);
        }
    }
}

