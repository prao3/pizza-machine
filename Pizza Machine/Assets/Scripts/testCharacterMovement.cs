using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharacterMovement : MonoBehaviour {

    //The rigid body of the player object
    private Rigidbody2D playerRigidBody2D;

    //The speed of the player object when moving
    private float speed = 4.0f;

    //How high the player object can jump
    private float jumpPower = 5.0f;

    //Checks if the player is on the ground
    private bool grounded = true;

	// Use this for initialization
	void Start () {

        //Getting the rigid body of the player
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		
	}
	
	// Update is called once per frame hopefully
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
            right();

        else if (Input.GetKey(KeyCode.LeftArrow))
            left();
        

        //Checking if the player object can jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
            jump();
		
	}

    //Returns a value indicating if the player object is on the ground or not
    public bool isGrounded()
    {
        return grounded;
    }

    //Checks if the player object is on the ground
    void OnCollisionEnter2D(Collision2D coll)
    {
        grounded = true;
    }

    //Checks if the player object has left the ground
    void OnCollisionExit2D(Collision2D coll)
    {
        if (isGrounded())
        {
            grounded = false;
        }

    }

    //Lets the player object jump
    void jump()
    {
        playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
    }

    void left()
    {
        playerRigidBody2D.velocity = new Vector2(-speed, playerRigidBody2D.velocity.y);
    }

    void right()
    {
        playerRigidBody2D.velocity = new Vector2(speed, playerRigidBody2D.velocity.y);
    }

}
