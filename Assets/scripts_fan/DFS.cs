using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DFS
{
	public Material visitedMaterial;
	private LinkedList<GraphNode> visited;
    private GameObject results;
    private string traverse = "DFS Traverse result: ";

    public DFS ()
	{
		visited = new LinkedList<GraphNode> ();
	}

	public DFS (Material visitedMaterial)
	{
		this.visitedMaterial = visitedMaterial;
		visited = new LinkedList<GraphNode> ();
	}


	public LinkedList<GraphNode> findDFS (GraphNode startNode, GraphNode endNode, bool spanTree)
	{
		
		if (visited != null) {
			visited = new LinkedList<GraphNode> ();
		}
		Stack<GraphNode> dfsStack = new Stack<GraphNode> ();
		visited.AddLast (startNode);
		dfsStack.Push (startNode);
		startNode.Parent = null;


		while (!(dfsStack.Count == 0)) {

            GraphNode node = dfsStack.Peek ();
            GraphNode neighbour = getAdjUnvisitedVertex (node);

			if ((node.NodeValue == endNode.NodeValue) && spanTree == false) {
				return constructPath (node);

			} else {

				if (neighbour == null) {
					dfsStack.Pop ();
				} else {
					visited.AddLast (neighbour);
					neighbour.Parent = node;
					node.Edges.Add (neighbour);
					neighbour.objReference.GetComponent<MeshRenderer> ().material = visitedMaterial;
					dfsStack.Push (neighbour);
				}
			}
		

		}
		foreach (GraphNode node in visited) {
            results = GameObject.FindGameObjectWithTag("Result");
            traverse = traverse + node.NodeValue.ToString();
            results.GetComponent<TextMesh>().text = traverse;
            Debug.Log(traverse);

            Debug.Log (node.NodeValue);
		}
		return null;
	}


	private LinkedList<GraphNode> constructPath (GraphNode node)
	{
		LinkedList<GraphNode> path = new LinkedList<GraphNode> ();

		while (node != null) {

			path.AddLast (node);
			node = node.Parent;
		}

		return path;
	}

	public GraphNode getAdjUnvisitedVertex (GraphNode node)
	{
		foreach (GraphNode neighbour in node.Neighbours) {
			if (!visited.Contains (neighbour)) {
				neighbour.Parent = node;
				return neighbour;
			}
		}
		return null;
	}
}
