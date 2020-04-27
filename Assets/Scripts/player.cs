using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody myRigidbody;
    public Transform sphereTransform;
    float speed = 10;
    int coinCount = 0;
    public GameObject coinPrefab;

    void Start()
    {
        //-- resets starting posiotion to 0, 0,0 0
        //transform.position = new Vector3(0, 0, 0);

        //-- sphereTransform var is assigned to the sphere on the cube game object, and the next line then makes the sphere a child of the cube
        //sphereTransform.parent = transform;

        //-- change size of the object on start
        //sphereTransform.localScale = Vector3.one * 2;
        //-- or sphereTransform.localScale = new Vector3(2, 2, 2);

        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() { 

        //-- INPUT BASED MOVEMENT --//

        //-- moves the cube along with the arrow keys in a smooth transition
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;
        //print(transform.position);

        //-- TIME BASED MOVEMENT --//

        //-- rotates 180 per second
        //transform.eulerAngles += Vector3.up * 180 * Time.deltaTime;
        //-- or transform.eulerAngles += new Vector3(0,180 *Time.deltaTime,0);

        //-- rotates around y axis of parent object
        //transform.Rotate(Vector3.up * 180 * Time.deltaTime);

        //-- moves forward 7 per. local will run in circle, global will z axis into space (Space.world)
        //transform.Translate(Vector3.forward * Time.deltaTime * 7);

        //-- pressing space bar resets the sphere's location to zero
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            sphereTransform.position = Vector3.zero;
            //vs this, which will snap to the location of the parent instead of the world
            //sphereTransform.localPosition = Vector3.zero;
        }*/

        //-- spawn a new coin on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
        }
        

        //-- PHYSICS BASED MOVEMENT --//
    }
    void FixedUpdate()
    {
        //myRigidbody.position += velocity * Time.deltaTime;
    }
    void OnTriggerEnter(Collider triggerCollider)
    {
        //-- OBJECT INTERACTION --//

        if (triggerCollider.tag == "Coin")
        {
            //-- Destroy object on interaction
            Destroy(triggerCollider.gameObject);
            coinCount++;

            //-- Create new prefab on interaction with random rotate and position
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            print(coinCount);



        }
    }

}
