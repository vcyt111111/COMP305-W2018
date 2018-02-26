using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    //public variables
    public float maxSpeed = 10.0f;
    public float jumpForce = 200.0f;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask defineGround;

    //Private variables
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float moveH;
    private bool isRight;
    private bool isGrounded;
    
    // Use this for initialization
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        sRend = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    //used for physics calculation
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        //Debug.Log("Ground? " + isGrounded);
        animator.SetBool("Ground", isGrounded);
        animator.SetFloat("vSpeed", rBody.velocity.y);

        if (isGrounded)
        {
            moveH = Input.GetAxis("Horizontal");

            //pass horizontal velocity to animator (Speed)
            animator.SetFloat("Speed", Mathf.Abs(moveH));

            //Debug.Log("Move Horizontal: " + moveHoriz);
            rBody.velocity = new Vector2(moveH * maxSpeed, rBody.velocity.y);

            if (moveH > 0)
            {
                sRend.flipX = false;
            }
            else if (moveH < 0)
            {
                sRend.flipX = true;
            }
        }
    }
}
