using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] private TMP_Text Scoring;
    public float speed = 5.0f; 
    public int direction = 1; 
    public float jumpForce = 5.0f; 
    public bool isGrounded = true; 
    public SpriteRenderer spriteRenderer;

    public Animator animator;
    public int coin;
    //private Score scoreC;
    public GameObject ScorePanel;
    //public AudioSource jump;
    //public AudioSource Death;
    // public AudioSource Music;
    // public AudioSource Coin;
    private Rigidbody2D rb;
    //public GameObject Heath1;
    //public GameObject Heath2;
    //public GameObject Heath3;
    //private int Heath = 3;
    // private time ti;
    public TextMeshPro timeGO;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //coin = 0;
        //Scoreing.text = "" + coin;
        ScorePanel.SetActive(false);
        //Heath2.SetActive(true);
        //Heath1.SetActive(true);
        //Heath3.SetActive(true);

        //Music.Play();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            transform.Translate(new Vector2(x * speed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            if (animator != null)
            {
                animator.SetBool("isJump", true);
                //jump.Play();
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (animator != null)
        {
            animator.SetBool("isRunning", x != 0); // Set the running animation based on horizontal input
            animator.SetBool("isIdle", x == 0); // Set the idle animation state
        }

        Vector3 currentScale = transform.localScale;
        //if (x > 0)
        //{
        //    direction = 1; // Set direction to right
        //    transform.localScale = new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z); // Face right
        //    //spriteRenderer.flipX = false; 
        //}
        //else if (x < 0)
        //{
        //    direction = -1; // Set direction to left
        //    transform.localScale = new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z); // Face left
        //    //spriteRenderer.flipX = true; 
        //}

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (animator != null)
                animator.SetBool("isJump", false);
            Debug.Log("Collision detected with:Ground ");
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision detected with:Enemy ");
            // Check if player is above the enemy (jumping on head)
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    Destroy(collision.gameObject); // Enemy dies
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Bounce player up
                    return;
                }
            }
            // If not jumping on head, you can add damage logic here
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin");
            coin += 1;
            Scoring.text = "Score:" + coin;
            Destroy(collision.gameObject);
            //Coin.Play();
        }
        
        //if (collision.gameObject.CompareTag("DEATH"))
        //{
        //    // Heath -= 1;
        //    if (Heath == 2)
        //    {
        //        Heath3.SetActive(false);
        //    }
        //    if (Heath == 1)
        //    {
        //        Heath2.SetActive(false);
        //    }
        //    if (Heath == 0)
        //    {

        //        Heath1.SetActive(false);
        //        Music.Stop();
        //        Time.timeScale = 0;
        //        ScorePanel.SetActive(true);
        //        ScoreGO.text = "" + coin;
        //        Death.Play();
        //    }

        //}
    }
}
