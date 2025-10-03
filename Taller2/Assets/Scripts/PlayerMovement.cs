using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 4f;
    public float jumpForce = 15f;

    [Header("Ground Check")] 
    [SerializeField] private Transform groundCheck;   
    [SerializeField] private LayerMask groundLayer;   

    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Run", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.86f, 1.86f, 1.86f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.86f, 1.86f, 1.86f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}