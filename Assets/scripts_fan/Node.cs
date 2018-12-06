using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphNode {

	private int nodeValue;

	private List<GraphNode> neighbours;

	private List<GraphNode> edges;

	private GraphNode parent;

	private int nodeRow;

	private int nodeColumn;


    public GameObject objReference;

	public float animationOffset;


    public GraphNode(){

		animationOffset = Random.Range (0.0f, 1.0f);
		neighbours = new List<GraphNode> ();
		edges = new List<GraphNode> ();
    }

	public int NodeValue {
		get { return nodeValue; }

		set { this.nodeValue = value; }

	}

	public List<GraphNode> Neighbours {
		get { return neighbours; }

		set { this.neighbours = value; }

	}

	public List<GraphNode> Edges {
		get { return edges; }

		set { this.edges = value; }

	}

	public GraphNode Parent
    {
		get { return parent; }

		set { this.parent = value; }

	}

	public int NodeRow {
		get{ return nodeRow; }

		set{ nodeRow = value; }
	}

	public int NodeColumn{
		get{return  nodeColumn;}

		set {nodeColumn = value;}
	}

	public GameObject ObjReference {
		get{ return objReference; }

		set{ objReference = value; }
	}
		
}
