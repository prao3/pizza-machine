using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    private Vector3 lastPlayerPosition1;
    private float distanceToMove1;
    private Vector3 lastPlayerPosition2;
    private float distanceToMove2;
    public Camera camera;

    // Use this for initialization
    void Start()
    {
        lastPlayerPosition1 = player1.transform.position;
        lastPlayerPosition2 = player2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove1 = player1.transform.position.x - lastPlayerPosition1.x;
        distanceToMove2 = player2.transform.position.x - lastPlayerPosition2.x;
        //5 is an arbitrary value where the camera is in a good spot
        if (!(playerDist() <= 5) /*|| !(playerDist() >= 25)*/)
            FixedCameraFollowSmooth(camera, player1.transform, player2.transform);
        //Just move the camera normally
        else
        {
            camera.transform.position = new Vector3(camera.transform.position.x + ((distanceToMove1 + distanceToMove2) / 2), camera.transform.position.y, camera.transform.position.z);
        }
        lastPlayerPosition1 = player1.transform.position;
        lastPlayerPosition2 = player2.transform.position;
    }

    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.8f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }

        cam.transform.position = new Vector3(cam.transform.position.x + ((player1.transform.position.x + player2.transform.position.x) / 2), cam.transform.position.y, cam.transform.position.z);
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.005f)
            cam.transform.position = cameraDestination;
    }

    public float playerDist()
    {
        return (player1.transform.position - player2.transform.position).magnitude;
    }
}