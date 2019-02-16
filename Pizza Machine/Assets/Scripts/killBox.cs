using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour
{

    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {

        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kill Box"))
        {
            Debug.Log(col.gameObject.tag);
            transform.position = start;
        }
    }
}
