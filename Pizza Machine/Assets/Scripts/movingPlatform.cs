using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    public float xspeed = 1.0f;
    public float yspeed = 1.0f;
    public float oscTime = 1.0f;
    private bool flip = true;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time >= oscTime)
        {
            flip = !flip;
            time = 0;
        }

        if (flip)
            transform.position = transform.position + new Vector3(xspeed, yspeed, 0);

        else
            transform.position = transform.position - new Vector3(xspeed, yspeed, 0);

        //Debug.Log(time);
        //Debug.Log("flip = " + flip);

    }
}
