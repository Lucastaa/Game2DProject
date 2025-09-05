using TMPro;
using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    public GameObject explosionPrefab;
    public Animator animator;
    public int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(x * speed, y * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(DestroyDelay());
            //Destroy(explosionPrefab);
        }
        if (collision.gameObject.CompareTag("Leg"))
        {
            Destroy(collision.gameObject);
            points += 1;
            Debug.Log("Points: " + points);
        }
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}
