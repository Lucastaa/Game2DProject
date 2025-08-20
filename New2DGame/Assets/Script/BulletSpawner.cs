using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);
            
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 10f * Time.deltaTime;
            Debug.Log("Bullet spawned at position: " + transform.position);
            if (transform.position.x > 100)
            {
                Destroy(bullet);
            }
        }
    }
}
