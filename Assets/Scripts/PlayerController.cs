using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float jumpForce;

    //This says hey a rigid body is gonna be on the player
    private Rigidbody2D rbPlayer1;
    private SpriteRenderer mySpriteRenderer;

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

    public float camOffsety;
    private GameObject cam;
    private GameObject degen;

    private GameObject camwithChild;


    // Use this for initialization
    void Start () {
        //gets the rigid body on player and attaches to variable
        rbPlayer1 = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            mySpriteRenderer.flipX = true;
        }
        else if(rbPlayer1.velocity.x > 0)
        {//if going right
            mySpriteRenderer.flipX = false;
        }

        anima.SetFloat("Speed", Mathf.Abs(rbPlayer1.velocity.x));
        anima.SetBool("Grounded", isGrounded);

        //this makes main camera follow player (cant be parented because of the above flip for sprite)

        cam = GameObject.Find ("Confusion");
        cam.transform.position = new Vector3(rbPlayer1.position.x, rbPlayer1.position.y+camOffsety,-10);
        /*
        degen = GameObject.Find("PlatformDegenerationPoint");
        degen.transform.position = new Vector3(cam.transform.position.x-50, cam.transform.position.y + camOffsety, -10);
*/

    }
}
