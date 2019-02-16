using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharacterMovement2 : MonoBehaviour {

    //The rigid body of the player object
    private Rigidbody2D playerRigidBody2D;

    //The speed of the player object when moving
    private float speed = 4.0f;

    //How high the player object can jump
    private float jumpPower = 5.0f;

    //Checks if the player is on the ground
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {

        //Getting the rigid body of the player
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
            playerRigidBody2D.velocity = new Vector2(speed, playerRigidBody2D.velocity.y);

        else if (Input.GetKey(KeyCode.A))
            playerRigidBody2D.velocity = new Vector2(-speed, playerRigidBody2D.velocity.y);


        //Checking if the player object can jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
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
        if (coll.gameObject.CompareTag("ground"))
            grounded = true;
    }

    //Checks if the player object has left the ground
    void OnCollisionExit2D(Collision2D coll)
    {
        if (isGrounded() && coll.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }

    }

    //Lets the player object jump
    void jump()
    {
        playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
    }

}
