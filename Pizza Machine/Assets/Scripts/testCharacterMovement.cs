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

    public bool isGrounded()
    {
        return grounded;
    }
	
	// Update is called once per frame hopefully
	void Update () {

        movePlayerVector = Input.GetAxis("Horizontal");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
            jump();
      /*  if ((!isGrounded() ) && (playerRigidBody2D.velocity.y == 0))
        {
            grounded = true;
        }*/
		
	}

<<<<<<< HEAD
    void OnTriggeredEnter2D(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
            grounded = true;
=======
  void OnCollisionStay(Collision coll)
    {
        grounded = true;
    }
    void OnCollisionExit(Collision coll)
    {
        if (isGrounded())
        {
            grounded = false;
        }
>>>>>>> a369152d1021a78b796ce6f07deeb74e28a9344c
    }

<<<<<<< HEAD
    void OnTriggeredExit2D(Collision other)
=======
    void jump()
    {
        playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpPower);
    }
<<<<<<< HEAD
    void OnTriggeredExit2D()
>>>>>>> c4b5a637817f287d6059775a9d5590c619b6c63b
    {
        grounded = false;
    }
=======

>>>>>>> a369152d1021a78b796ce6f07deeb74e28a9344c
}
