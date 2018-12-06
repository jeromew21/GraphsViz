using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNodes : MonoBehaviour {

    public GameObject nodePrefab;

    public GameObject edgePrefab;

    public List<GameObject> vertices;

    public OVRInput.Controller controller;

    public GameObject Anchor;

    private float indexTriggerState = 0;
    private float handTriggerState = 0;
    private float oldIndexTriggerState = 0;

    public GameObject root;

    public GameObject brain;

    private bool depressedHand;

    private bool goTraverse;

    void Traverse()
    {
        brain.GetComponent<GraphMethods>().Traverse();
    }

	// Use this for initialization
	void Start () {
        vertices = new List<GameObject>();
        depressedHand = false;
        goTraverse = false;
        Anchor.AddComponent(typeof(SphereCollider));
        SphereCollider myCollider = Anchor.transform.GetComponent<SphereCollider>();
        myCollider.radius = 0.05f; // or whatever radius you want.
        Anchor.GetComponent<SphereCollider>().enabled = false; //This could work for almost any component
    }
	
	// Update is called once per frame
	void Update () {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        Creation();
        if (depressedHand)
        {
            if (handTriggerState < 0.9f)
            {
                BeFree();
            }
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Anchor.GetComponent<SphereCollider>().enabled = true;
            goTraverse = false;
        }  
        if (OVRInput.Get(OVRInput.Button.Two) && !goTraverse)
        {
            goTraverse = true;
            Traverse();
        }
    }

    void InstantiateNode()
    {
        depressedHand = true;
        GameObject node = Instantiate(nodePrefab, OVRInput.GetLocalControllerPosition(controller), Quaternion.identity);
        if (vertices.Count == 0)
        {
            root = node;
            vertices.Add(node);
            brain.GetComponent<GraphMethods>().root = root;
        }
        else
        {
            vertices.Add(node);
            root.GetComponent<GVNode>().neighbors.Add(node);
            
        }
    }

    
    

    void Creation()
    {
        if (handTriggerState > 0.9f && !depressedHand)
        {
            InstantiateNode();
        }
        if (indexTriggerState > 0.9f)
        {
            root.GetComponent<GVNode>().MakeConnections();
        }
    }

    void BeFree()
    {
        depressedHand = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("node"))

        {
            print("ya yeet");
            root = other.gameObject;
        }
    }
}
