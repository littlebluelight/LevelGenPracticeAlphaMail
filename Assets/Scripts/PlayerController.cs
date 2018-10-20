using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float jumpForce;

    //This says hey a rigid body is gonna be on the player
    private Rigidbody2D rbPlayer1;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    //public KeyCode crouch; currently unused
    //public KeyCode attackA; currently unused

    //sets up animator
    private Animator anima;

    //for animator to see if is on the ground
    public bool isGrounded;
    //variable for checking if we are in the ground
    public float groundCheckRadius;
    public Transform groundCheckPoint;
    public LayerMask whatisGround;

    // Use this for initialization
    void Start () {
        //gets the rigid body on player and attaches to variable
        rbPlayer1 = GetComponent<Rigidbody2D>();
        anima = GetComponent < Animator >();
	}
	
	// Update is called once per frame

	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius,whatisGround);

        //if player pushes both left and right they don't move 
        if (Input.GetKey(right) && Input.GetKey(left))
        {
            rbPlayer1.velocity = new Vector2(0, rbPlayer1.velocity.y);
        }

        //if character moves left, create new vector moving left
        else if (Input.GetKey(left))
        {
            rbPlayer1.velocity = new Vector2(-walkSpeed, rbPlayer1.velocity.y);
        }

        //if character moves right, create new vector moving right
        else if (Input.GetKey(right))
        {
            rbPlayer1.velocity = new Vector2(walkSpeed, rbPlayer1.velocity.y);
        }

        //this next else statement makes it so that the player wont continue moving after keypress
        else{
            rbPlayer1.velocity = new Vector2(0, rbPlayer1.velocity.y);
        }

        //when the jump button is pushed, add jumpForce to the x value
        if (Input.GetKeyDown(jump) && isGrounded){
            rbPlayer1.velocity = new Vector2(rbPlayer1.velocity.x, jumpForce);
        }

        //This just flips animations/everything when facing left
        if(rbPlayer1.velocity.x<0){//if going left
            transform.localScale = new Vector3(-1, 1, 1);//make face left
        }
        else if(rbPlayer1.velocity.x > 0)
        {//if going right
            transform.localScale = new Vector3(1, 1, 1);//make face left
        }

        anima.SetFloat("Speed", Mathf.Abs(rbPlayer1.velocity.x));
        anima.SetBool("Grounded", isGrounded);

    }
}
