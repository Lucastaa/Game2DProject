using UnityEngine;

public class ChickenMovement2 : MonoBehaviour
{
    public float speed = 2f;
    public Transform PointA;
    public Transform PointB;
    public int health = 10;

    [Header("Wave Settings (Y axis)")]
    public float amplitude = 0.5f;
    public float frequency = 2f;

    [Header("Random Backstep Settings")]
    public float backstepDistance = 0.3f;
    public float backstepChance = 0.2f;
    public float backstepDuration = 0.2f;

    private Vector3 startPos;
    private bool movingToB = true;
    private bool isBackstepping = false;
    private float backstepTimer = 0f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (!isBackstepping)
        {
            Vector3 target = movingToB ? PointB.position : PointA.position;
            Vector3 dir = (target - transform.position).normalized;

            transform.position += dir * speed * Time.deltaTime;

            float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
            transform.position = new Vector3(transform.position.x, y, startPos.z);

            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                movingToB = !movingToB;
            }

            if (Random.value < backstepChance * Time.deltaTime)
            {
                isBackstepping = true;
                backstepTimer = backstepDuration;
            }
        }
        else
        {
            Vector3 target = movingToB ? PointB.position : PointA.position;
            Vector3 dir = (target - transform.position).normalized;

            transform.position -= dir * (backstepDistance / backstepDuration) * Time.deltaTime;

            backstepTimer -= Time.deltaTime;
            if (backstepTimer <= 0f)
            {
                isBackstepping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}