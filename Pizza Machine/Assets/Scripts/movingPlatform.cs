using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    public float xspeed = 1.0f;
    public float yspeed = 1.0f;
    public float oscTime = 1.0f;
    private bool flip = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.deltaTime % oscTime == 0)
            flip = !flip;

        if (flip)
            transform.position = transform.position + new Vector3(xspeed, yspeed, 0);

        else
            transform.position = transform.position + new Vector3(-xspeed, -yspeed, 0);

    }
}
