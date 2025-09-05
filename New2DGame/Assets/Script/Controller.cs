using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public Rigidbody2D rb;
    public Vector2 movementInput;
    

    public float jumpForce = 5f;
    public bool isGrounded = true;
    public InputActions inputActions;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputActions();

        inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => movementInput = Vector2.zero;
        inputActions.Player.Jump.performed += ctx => Jump();
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
    }
    public void OnDisable()
    {
        inputActions.Player.Disable();
    }
    public void Update()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", movementInput.magnitude * moveSpeed);
            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Vertical", movementInput.y);
        }

        if (movementInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (movementInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
            Debug.Log("Jumping");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (animator != null)
            {
                animator.SetBool("Jump", false);
            }
        }
    }
}