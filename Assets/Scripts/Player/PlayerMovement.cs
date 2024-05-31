using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public bool isMoving = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public SpriteRenderer spriteRender;

    Animator anim;

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        //WALKING
        anim.SetBool("Walking", isMoving);

        horizontal = Input.GetAxisRaw("Horizontal");

       

        if(rb.velocity.x > 1 || rb.velocity.x < -1 && IsGrounded())
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

        //JUMPING
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (rb.velocity.y < 0f)
        {
            anim.SetBool("Falling", !IsGrounded());
        }

        anim.SetBool("Jumping", !IsGrounded());

        Flip();

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            spriteRender.flipX = true;
        }

        if (!isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            spriteRender.flipX = false;
        }
    }

    private void Dodge()
    {
        anim.SetBool("Dodge", true);
    }

}
