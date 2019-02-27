﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //The rigid body of the player object
    private Rigidbody2D playerRigidBody2D;

    //The speed of the player object when moving
    public float speed = 4.0f;

    //How high the player object can jump
    public float jumpPower = 5.0f;

    //Checks if the player is on the ground
    private bool grounded = true;

    //an int to keep track of jumps
    private int jumpCount = 0;
    public KeyCode left;
    public KeyCode up;
    public KeyCode right;

    public Player(KeyCode left, KeyCode right, KeyCode up)
    {
        this.left = left;
        this.right = right;
        this.up = up;
    }

    // Start is called before the first frame update
    void Start()
    {

        //Getting the rigid body of the player
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(right))
            playerRigidBody2D.velocity = new Vector2(speed, playerRigidBody2D.velocity.y);

        else if (Input.GetKey(left))
            playerRigidBody2D.velocity = new Vector2(-speed, playerRigidBody2D.velocity.y);


        //Checking if the player object can jump
        if (Input.GetKeyDown(up) && jumpCount < 2)
            jump();

    }

    //Returns a value indicating if the player object is on the ground or not
    public bool isGrounded()
    {
        return grounded;
    }

    //Checks if the player object is on the ground
    void OnCollisionEnter2D(Collider coll)
    {
        if (collideWithGround(coll))
        {
            grounded = true;
            jumpCount = 0;
        }
        if (collideWithPlayer(coll))
        {
            grounded = true;
            jumpCount = 1;
        }

    }

    //Checks if the player object has left the ground
    void OnCollisionExit2D(Collider exit)
    {
        if (collideWithPlayer(exit))
        {
            if (collideWithGround(exit))
            {
                grounded = false;
                jumpCount++;
            }

        }

        if (collideWithPlayer(exit) && jumpCount == 1)
            grounded = false;

        if (collideWithGround(exit))
            grounded = false;

    }

    bool collideWithPlayer(Collider coll)
    {
        return coll.gameObject.CompareTag("Player");
    }

    bool collideWithGround(Collider coll)
    {
        return coll.gameObject.CompareTag("ground");
    }

    //Lets the player object jump
    void jump()
    {
        jumpCount++;
        playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
    }

}
