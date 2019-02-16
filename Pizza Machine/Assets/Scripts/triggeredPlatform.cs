using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeredPlatform : MonoBehaviour
{

    //The detection collider on the platform
    public Collider2D trig;

    //Checks if the platform is allowed to move
    private bool canMove = false;

    //Keeping track of how long the platform moves
    private float time = 0.0f;

    //When the platform should stop moving after it has started
    public float stopTime = 0.0f;

    //The x direction speed of the platform
    public float xspeed = 0.0f;

    //The y direction speed of the platform
    public float yspeed = 0.0f;

    //The velocity vector of the platform
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

        //Creating the velocity vector with xspeed and yspeed
        velocity = new Vector3(xspeed, yspeed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Checks if the platfrom can move and moves the platform for a specified period of time
        if(canMove == true)
        {
            //Incrementing the time
            time += Time.deltaTime;

            //Checking if the platform has been moving for longer than stopTime
            if (time >= stopTime)
                canMove = false;

            //Moving the platform
            transform.position = transform.position + velocity;
        }

    }

    //When triggered, destroy the collider that checks for the trigger
    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(trig);
        canMove = true;
    }

}
