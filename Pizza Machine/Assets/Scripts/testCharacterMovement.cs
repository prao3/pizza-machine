using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharacterMovement : MonoBehaviour {

    private Rigidbody2D playerRigidBody2D;
    private float movePlayerVector;
    private float speed = 4.0f;
    private float jumpPower = 5.0f;
    private bool grounded = true;

	// Use this for initialization
	void Start () {

        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		
	}
	
	// Update is called once per frame hopefully
	void Update () {

        movePlayerVector = Input.GetAxis("Horizontal");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            jump();
		
	}

    void OnTriggeredEnter2D(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
            grounded = true;
    }

<<<<<<< HEAD
    void OnTriggeredExit2D(Collision other)
=======
    void jump()
    {
        playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
    }
    void OnTriggeredExit2D()
>>>>>>> c4b5a637817f287d6059775a9d5590c619b6c63b
    {
        grounded = false;
    }
}
