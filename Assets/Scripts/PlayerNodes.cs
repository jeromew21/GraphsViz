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
        //OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)

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
        //GameObject node = Instantiate(nodePrefab, OVRInput.GetLocalControllerPosition(controller);
        //vertices.Add(node);
    }

    void DrawEdge(Node start, Node end)
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

    /**
    public void add()
    {
        int mindex = 1;
        HashSet<GameObject> used = new HashSet<GameObject>();
        foreach (GameObject node in vertices)
        {
            used.Add(node);
        }
        for (int i = 1; i < ; i++)
        {
            if (!used.contains(i))
            {
                mindex = i;
                break;
            }
        }

        _vertices.add(mindex);

        while (_edges.size() <= mindex)
        {
            _edges.add(null);
            _adjacent.add(null);

        }
        _edges.set(mindex, new ArrayList<>());
        _adjacent.set(mindex, new ArrayList<>());
        return mindex;
    }
    

    @Override
    public int add(int u, int v)
    {
        checkMyVertex(u);
        if (_edges.get(u).contains(v))
        {
            return _edges.get(u).get(v);
        }
        while (_edges.get(u).size() <= _unique)
        {
            _edges.get(u).add(null);
        }
        _edges.get(u).set(_unique, v);
        _adjacent.get(u).add(v);
        _numEdges++;
        return _unique++;
    }

    @Override
    public void remove(int v)
    {
        if (contains(v))
        {
            if (isDirected())
            {
                _numEdges = _numEdges - outDegree(v);
                _vertices.remove(new Integer(v));
                _edges.remove(new Integer(v));
                _adjacent.set(v, null);
            }
            else
            {
                _numEdges = _numEdges - outDegree(v);
                _vertices.remove(new Integer(v));
                _edges.remove(new Integer(v));
                _adjacent.set(v, null);
            }
        }
    }

    public void remove(int u, int v)
    {
        if (contains(u, v))
        {
            int vIndex = edges.get(u).indexOf(v);
            edges.get(u).set(vIndex, null);

            adjacent.get(u).remove(v);
            _numEdges--;
        }
    }
    */

    /** Unique identifying value for each edge. */
    private int _unique;

    /** Number of edges in a Graph. */
    private int _numEdges;
}
