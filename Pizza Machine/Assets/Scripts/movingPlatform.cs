using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    //Represents the speed of the platform in the x direction
    public float xspeed = 1.0f;

    //Represents the speed of the platform in the y direction
    public float yspeed = 1.0f;

    //The amount of time spent travelling before turning around
    public float oscTime = 1.0f;

    //Allows for flipping of direction after some duration of time
    private bool flip = true;

    //Tracking time between flips
    private float time = 0.0f;

    //The velocity vector of the platform
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

        //Assigning the velocity vector using xspeed and yspeed
        velocity = new Vector3(xspeed, yspeed, 0);

    }

    // Update is called once per frame
    void Update()
    {

        //Counting up in-game time
        time += Time.deltaTime;

        //Switching direction when time is larger than oscTime
        if (time >= oscTime)
        {
            flip = !flip;

            //Reseting time
            time = 0;
        }

        //Going the the right when flip is true
        if (flip)
            transform.position = transform.position + velocity;

        //Going to the left otherwise
        else
            transform.position = transform.position - velocity;

        //Debug.Log(time);
        //Debug.Log("flip = " + flip);

    }
}
