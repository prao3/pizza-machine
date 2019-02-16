using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour
{

    //The starting position of the player
    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {

        //Setting the starting position of the player to where the player is on start
        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checking if player is inside the kill box
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kill Box"))
        {
            //Moving the player back to the start (respawn)
            Debug.Log(col.gameObject.tag);
            transform.position = start;
        }
    }
}
