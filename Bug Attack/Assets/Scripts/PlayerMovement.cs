using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator; // Use if adding animations
    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private Vector3 respawnPoint;
    private GameObject fallDetector;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        // Get animator if using animations
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
        respawnPoint = transform.position;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0 && IsGrounded())
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
         // Calling Animations Here
        //if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        //{
        //    animator.SetBool("isRunning".true);
       // }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        // Player facing direction
        if (dirX > 0)
        {
            facingRight = true;
        }
        
        else if (dirX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



}
