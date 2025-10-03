using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 4f;
    public float jumpForce = 15f;

    [Header("Ground Check")] 
    [SerializeField] private Transform groundCheck;   // 👉 Aquí aparecerá el campo en el Inspector
    [SerializeField] private LayerMask groundLayer;   // 👉 Aquí asignas el Layer Ground

    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        // Animación de correr
        animator.SetFloat("Run", Mathf.Abs(horizontal));

        // Saltar solo si está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        // Flip de personaje
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.86f, 1.86f, 1.86f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.86f, 1.86f, 1.86f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        // Detecta si toca el suelo con el GroundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}