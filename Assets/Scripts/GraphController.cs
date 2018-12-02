using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

    public GameObject node;
    public GameObject edge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /**
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "node") {
                //instantiate an edge at the node position if clicked on a node
                Instantiate(edge, hitInfo.transform);
            } else {
                //instantiate a node at the mouse position if clicked on an empty space
                Vector3 pos = Input.mousePosition;
                Instantiate(node, pos, Quaternion.identity); 
            }
        }
        */
	}
}
