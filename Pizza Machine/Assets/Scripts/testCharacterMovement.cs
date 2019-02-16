using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharacterMovement : MonoBehaviour {

    private Rigidbody2D playerRigidBody2D;
    private float movePlayerVector;
    private float speed = 4.0f;
    private float jumpPower = 5.0f;
    private bool grounded = false;

	// Use this for initialization
	void Start () {

        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		
	}
	
	// Update is called once per frame
	void Update () {

        movePlayerVector = Input.GetAxis("Horizontal");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
		
	}

    void OnTriggeredEnter2D()
    {
        //if(other.gameObject.CompareTag("ground"))
            grounded = true;
    }

    void OnTriggeredExit2D()
    {
        grounded = false;
    }
}
