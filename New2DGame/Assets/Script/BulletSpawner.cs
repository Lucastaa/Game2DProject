using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Transform shootingPosition;
    public GameObject[] bulletPrefabs;
    public float speed = 20.0f;
    public int bulletIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //var bullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);
            
            //bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 20f;
            //Debug.Log("Bullet spawned at position: " + transform.position);
            //if (bullet.transform.position.y > 10)
            //{
            //    Destroy(bullet);
            //}
            Shoot();
        }
        //transform.position += Vector3.up * speed * Time.deltaTime;
    }
    void Shoot()
    {
        var bullet = Instantiate(bulletPrefabs[bulletIndex], shootingPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * 20f;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Destroy(collision.gameObject);
                return;
            }
        }
    }
}
