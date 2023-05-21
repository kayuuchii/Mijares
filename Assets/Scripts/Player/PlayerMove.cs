using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float sprintMultiplier = 1.5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical");  
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);  
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);  

        float currentMoveSpeed = moveSpeed; 

        if (isSprinting)
        {
            currentMoveSpeed *= sprintMultiplier;  
            animator.SetBool("IsSprinting", true);
        }
        else
        {
            animator.SetBool("IsSprinting", false); 
        }

        Vector2 direction = new Vector2(horizontal, vertical).normalized;  
        rb.velocity = new Vector2(direction.x * currentMoveSpeed, rb.velocity.y);  

        if (direction.x < 0)  
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)  
        {
            spriteRenderer.flipX = false;
        }

        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);  
            animator.SetBool("IsGrounded", true);
        }

        if (direction.x != 0 && isGrounded && !isJumping)  
        {
            animator.SetBool("IsWalking", true);  
        }
        else
        {
            animator.SetBool("IsWalking", false);  
            animator.SetBool("IsGrounded", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping) 
        {
            isJumping = true;  
            animator.SetBool("IsJumping", true);  
            animator.SetBool("IsWalking", false); 
            animator.SetBool("IsSprinting", false);  
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.Play("Jump");
        }
    }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))  
            {
                isJumping = false;  
            }
            if (other.gameObject.CompareTag("Box"))  
            {
                isJumping = false;  
            }
        }
    }



