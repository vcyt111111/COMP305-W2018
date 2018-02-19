using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    //public variables
    public float maxSpeed = 10.0f;
    public float jumpForce = 200.0f;
    public Transform groundCheck;
    public LayerMask defineGround;

    //Private variables
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private bool isGrounded = false;
    private float groundRadius = 0.2f;

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
        if (Input.GetKey(KeyCode.V) && isGrounded)
        {
            animator.SetBool("Ground", isGrounded);
            rBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    //used for physics calculation
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        //Debug.Log("Ground? " + isGrounded);
        animator.SetFloat("vSpeed", rBody.velocity.y);

        float moveHoriz = Input.GetAxis("Horizontal");

        //pass horizontal velocity to animator (Speed)
        animator.SetFloat("Speed", Mathf.Abs(moveHoriz));

        //Debug.Log("Move Horizontal: " + moveHoriz);
        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);

        if (moveHoriz > 0)
        {
            sRend.flipX = false;
        }
        else if (moveHoriz < 0)
        {
            sRend.flipX = true;
        }
    }
}
