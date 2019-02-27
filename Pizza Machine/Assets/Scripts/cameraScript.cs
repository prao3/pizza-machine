using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    private Vector3 _lastPlayerPosition1;
    private Vector3 _lastPlayerPosition2;
    private float _distanceToMovex1;
    private float _distanceToMovex2;
    private float _distanceToMovey1;
    private float _distanceToMovey2;
    public Camera camera;

    // Use this for initialization
    void Start()
    {
        _lastPlayerPosition1 = player1.transform.position;
        _lastPlayerPosition2 = player2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition1 = player1.transform.position;
        _distanceToMovex1 = playerPosition1.x - _lastPlayerPosition1.x;
        Vector3 playerPosition2 = player2.transform.position;
        _distanceToMovex2 = playerPosition2.x - _lastPlayerPosition2.x;

        _distanceToMovey1 = playerPosition1.y - _lastPlayerPosition1.y;
        _distanceToMovey2 = playerPosition2.y - _lastPlayerPosition2.y;
        //7 is an arbitrary value where the camera is in a good spot
        //if the players are fairly close or failry far away just lock the camera zoom and follow them
        if ((getPlayerDist() <= 7) /*&& (playerDist() >= 15)*/)
        {
            Vector3 transformPosition = camera.transform.position;
            camera.transform.position = new Vector3(transformPosition.x + averageDist(_distanceToMovex1, _distanceToMovex2),
               transformPosition.y + averageDist(_distanceToMovey1, _distanceToMovey2), transformPosition.z);
        }    
        //Just move the camera normally with player zoom
        else
        {
            FixedCameraFollowSmooth(camera, player1.transform, player2.transform);
        }
        _lastPlayerPosition1 = playerPosition1;
        _lastPlayerPosition2 = playerPosition2;
    }

    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.2f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude > 0 ? (t1.position - t2.position).magnitude  : (t2.position - t1.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }

        cam.transform.position = new Vector3(cam.transform.position.x + Mathf.Abs(((player1.transform.position.x - player2.transform.position.x))/2) , cam.transform.position.y, cam.transform.position.z);
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.005f)
            cam.transform.position = cameraDestination;
    }

    //returns the magnitude of the vecotr between the two players 
    public float getPlayerDist()
    {
        return (player1.transform.position - player2.transform.position).magnitude;
    }

    //Averages the two inputted floats
    public float averageDist(float dist1, float dist2)
    {
     return   (dist1 + dist2 )/ 2;
    }

}