using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCasting : MonoBehaviour
{
    //-- Sets so that you can give layers to be ignored
    public LayerMask mask; 
    // Update is called once per frame
    void Update()
    {
        //-- This should hopefully be pretty straightforward. The inst. call for ray has a lot of overloads I should look into
        //-- Items must have collider attached in order to be 'seen'
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, mask))
        {

            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
