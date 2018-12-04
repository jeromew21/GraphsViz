using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNodes : MonoBehaviour {

    public GameObject nodePrefab;

    public List<GameObject> vertices;
    public List<List<GameObject>> edges;

    public OVRInput.Controller controller;

    private float indexTriggerState = 0;
    private float handTriggerState = 0;
    private float oldIndexTriggerState = 0;

    // Use this for initialization
    void Start () {
        vertices = new List<GameObject>();
        edges = new List<List<GameObject>>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaceNode()
    {
        if (handTriggerState > 0.9f)
        {
            InstantiateNode();
        }
    }

    void InstantiateNode()
    {
        //GameObject node = Instantiate(nodePrefab, OVRInput.GetLocalControllerPosition(controller));
        //vertices.Add(node);
    }

    /**
    void DrawEdge(GameObject start, GameObject end)
    {

    }


    public bool isDirected() {
        return true;
    }
    
    public int outDegree(GameObject node)
    {
        return 0;
        // Implement later
    }

    public int inDegree(int v)
    {
        return 0;
        // Implement later
    }

    public bool contains(GameObject node)
    {
        return vertices.Contains(node);
    }

    public bool contains(GameObject start, GameObject finish)
    {
        return true;
    }

    public void add()
    {
        int mindex = 1;
        HashSet<GameObject> used = new HashSet<GameObject>();
        foreach (GameObject node in vertices)
        {
            used.Add(node);
        }
        for (int i = 1; i < vertices.Count; i++)
        {
            if (!used.Contains(i))
            {
                mindex = i;
                break;
            
        }

        vertices.Add(mindex);
        while (edges.Count <= mindex)
        {
            edges.add(null);       

        }
        _edges.set(mindex, new ArrayList<>());
        _adjacent.set(mindex, new ArrayList<>());
        return mindex;
    }
    
    public int add(int u, int v)
    {
        GVNode.CreateNewNeighbor(OVRInput.GetLocalControllerPosition(controller));
    }

    public void remove(int v)
    {
        if (contains(v))
        {
            if (isDirected())
            {
                vertices.remove(new Integer(v));
                edges.remove(new Integer(v));
            }
            else
            {
                vertices.remove(new Integer(v));
                edges.remove(new Integer(v));
            }
        }
    }
    
    public void remove(int u, int v)
    {
        if (contains(u, v))
        {
            //int vIndex = edges.get(u).indexOf(v);
            //edges.get(u).set(vIndex, null);
        }
    }
    */

    /** Unique identifying value for each edge. */
    private int _unique;

    /** Number of edges in a Graph. */
    private int _numEdges;
}
