using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform PointA;
    public Transform PointB;
    public int health = 10;

    [Header("Wave Settings (Y axis)")]
    public float amplitude = 0.5f;
    public float frequency = 2f;

    private Vector3 startPos;
    private float t = 0f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        t += Time.deltaTime * speed;

        float x = Mathf.PingPong(t, 1f);
        float targetX = Mathf.Lerp(PointA.position.x, PointB.position.x, x);

        float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(targetX, y, startPos.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
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
