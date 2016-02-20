using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour

{
    public static Transform target; //The target to focus camera on
    public float speed = 5f; //how fast the camera can rotate around the object
    public float zoom; //Changing camera Field of View to the zoom value
    public float maxZoom = 180; //maximum allowed zoom
    public float minZoom = 1; //minimum allowed zoom





    // Use this for initialization
    void Start()
    {
        //get the initial target to focus on
        target = GameObject.FindGameObjectWithTag("Component").GetComponent<Transform>();
        //Make the Camera look at the target
        transform.LookAt(target);
        //set the starting zoom to a reasonable value
        zoom = 60;

    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView = zoom; //change the FOV to match zoom
        CameraZoom(); //Allows zooming of the camera
        CameraPosition(); //Allows repositioning of the camera




    }

    void CameraPosition() //Allows repositioning of the camera
    {
        if (Input.GetMouseButton(0))//Change rotation of camera with the left mouse button
        {
            transform.LookAt(target); //Focus the camera on the target every frame
            //Change the x-axis of the camera with the mouse horizontal movemement
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
            //Change the y-axis of the camera with the mouse vertical movement
            transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y") * speed);

        }
    }

    void CameraZoom() //Allows zooming with the camera
    {

        if (Input.GetAxis("Mouse ScrollWheel") < 0) // zoom in with mouse scroll
        {
            if (zoom < maxZoom)//as long as the zoom is less than maximum allowed value
            {
                zoom++; //zoom out
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) //zoom out with mouse scroll
        {
            if (zoom > minZoom) //as long as the zoom is above the minimum allowed value
            {
                zoom--; // zoom out
            }
        }

    }
}






