using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class rayCasting : MonoBehaviour
{
    //-- Sets so that you can give layers to be ignored
    public LayerMask mask;
    public Camera gameCamera;
    public Transform objectToPlace;
    // Update is called once per frame
    void Update()
    {
        //-- This should hopefully be pretty straightforward. The inst. call for ray has a lot of overloads I should look into
        //-- Items must have collider attached in order to be 'seen'

        //-- If we want the cube with the ray, we activate here
        //--Ray ray = new Ray(transform.position, transform.forward);
        //-- If we want the camera with the ray we activate here. Requires taking collisions off of cube
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            //-- Print the name of what was hit and destroy it 
            //print(hitInfo.collider.gameObject.name);
            //GameObject hitObject = hitInfo.collider.gameObject.transform.parent.gameObject;
            //Destroy(hitInfo.collider.gameObject);

            //-- Use the camera position to see the mouse and use it to move a cube around
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
