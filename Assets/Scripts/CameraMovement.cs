using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool drag = false;



    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }


    private void LateUpdate()
    {   //When you click and hold you can drag the camera to places
        if (Input.GetMouseButton(0))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        //whithout clicking still able to move the mouse around
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference;
            Camera.main.transform.position = new Vector3(
            //Search for another method for the limiting of the camera movement, something with percentages would be nice
            Mathf.Clamp(Camera.main.transform.position.x, -15, 15),
            Mathf.Clamp(Camera.main.transform.position.y, -10, 10), transform.position.z);
        }

        //Will be replaced with a selecting method, reset camera is nice for the time being though
        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;
        
    }
}