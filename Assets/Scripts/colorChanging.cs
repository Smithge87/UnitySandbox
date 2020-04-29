using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class colorChanging : MonoBehaviour
{
    public GameObject cube;
    private MeshRenderer myRenderer;
    private Vector3 location = new Vector3(1, 2, 3);
    string[] possibleNames = { "Joe", "Josh", "Dan", "Sue" };
    int[] powersOfTwo = new int[5];
    int[,] board = new int[3, 3];
    List<string> names = new List<string>();
    IEnumerator currentMoveCoroutine;
    public Transform[] path;

    void Start () {

        //StartCoroutine(DoSomething(possibleNames, .5f));
        StartCoroutine(FollowPath());
    }

    void Update(){
        //SpaceBarListener();

        //-- scoots the block around on spacebar press. current routine is stored and checked so that it can finish 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }
            currentMoveCoroutine =  Move(Random.onUnitSphere *5, 8);
            StartCoroutine(currentMoveCoroutine);
        }
    }



    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator FollowPath()
    {
        //-- Takes the waypoints assigned in the view and moves the cube along them in order. 
        foreach (Transform waypoint in path)
        {
            //-- yield return means that the routine will finish before starting the next waypoint.
            //-- i think that works because it's not based on usert input
            yield return StartCoroutine(Move(waypoint.position, 8));
        }
    }
    /*IEnumerator  DoSomething(string[] messages, float delay)
    {
        foreach (string msg in messages)
        {
            print(name);
            yield return new WaitForSeconds(delay);
        }
    }*/

    public void OnClickRenderColor () {
        //Enables and disables the color of the cube  - GameObject linked to cube and function linked to button
        myRenderer = cube.GetComponent<MeshRenderer>();
        myRenderer.enabled = !myRenderer.enabled;
    }
    public void SpaceBarListener(){
        // Looks for the space bar being pressed and logs message
        /*if (Input.GetKeyDown(KeyCode.Space)){
            print("Space Bar Pressed");
        }
        */
        
    }




}
