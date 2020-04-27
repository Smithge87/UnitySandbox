using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaser : MonoBehaviour
{
    //adding this variable, attaching the script to the object  (sphere), and dragging the cube to the var in the inspector make their movements relate
    public Transform targetTransform;
    float speed = 7;
    // Update is called once per frame
    void Update()
    {
        Vector3 displacementFromTarget = targetTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * speed;

        float distanceToTarget = displacementFromTarget.magnitude;
        if (distanceToTarget > 1.5f)
        {
            transform.Translate(velocity * Time.deltaTime);

        }
    }
}
