using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 Vec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vec.x = Input.GetAxisRaw("Horizontal");
        Vec.y = Input.GetAxisRaw("Vertical");
        //if (Vec.x > 0)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //}
        //else if (Vec.x < 0)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //}
    }
    void FixedUpdate()
    { 
        rb.MovePosition(rb.position + Vec.normalized * speed * Time.fixedDeltaTime);
    }
    void OnMove(InputValue value)
    {         
        Vec = value.Get<Vector2>();
    }
    void LateUpdate()
    {
        if (Vec.x > 0)
        {
            sr.flipX = false;
        }
        else if (Vec.x < 0)
        {
            sr.flipX = true;
        }
    }
}
