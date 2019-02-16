using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeredPlatform : MonoBehaviour
{

    public Collider2D trig;

    private bool canMove = false;
    private float time = 0.0f;
    public float stopTime = 0.0f;
    public float xspeed = 0.0f;
    public float yspeed = 0.0f;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

        velocity = new Vector3(xspeed, yspeed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canMove == true)
        {
            time += Time.deltaTime;

            if (time >= stopTime)
                canMove = false;

            transform.position = transform.position + velocity;
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(trig);
        canMove = true;
    }

}
