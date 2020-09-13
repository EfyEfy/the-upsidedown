using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables

        //Walking Variables
    public float Speed;
    float MoveInput;
    public bool isFacingRight;
        
        //RigidBody
    public Rigidbody2D rb;
        
        //Jumping Variables
    public float JumpForce;
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    
        //Defing what the ground is and defing the variables for the GroundCheck and putting the GroundCheck in
    public LayerMask Ground;
    public bool isGrounded;
    public float GroundCheckRadius;
    public Transform GroundCheck;

    void Start()
    {
   
    }

    
    void Update()
    {
            //the player jumps until he lets go of the button OR he reaches the jumps max heght
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;

        }
    } 

    void FixedUpdate()
    {
            //checking if the circlecast overlaps a gameobject thats on a specific Layer(Ground)
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
      

        //Moves the player by multipliying his MoveInput by Speed
        MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);

            //flips the player if hes facing the wrong direction
        if (isFacingRight == true && MoveInput < 0)
        {
            Flip();

        }
        else if (isFacingRight == false && MoveInput > 0)
        {
            Flip();
        }
    }
            //flips the player to face the right direction
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
//this was old code i did for some platformer game i was doing it also had wall jumping that couldnt work i removed that
//this code could still maybe be optimized but i dont really care rn
