using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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


    void Start () {
    }

    void Update(){
        //SpaceBarListener();
    }

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
