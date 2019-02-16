using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Use this for initialization
    void Start()
    {
        lastPlayerPosition = player1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player1.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y , transform.position.z);

        lastPlayerPosition = player1.transform.position;
    }
}