using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovementComponent : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Vector2 movementInput;
    public SpriteRenderer spriteRenderer;


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    public void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        Vector3 currentScale = transform.localScale;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = moveX < 0 || moveY < 0;
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    public void SpindButton()
    {
        Debug.Log("Spin button pressed");
    }
}