using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class BFS
{
	public Material visitedMaterial;
    private string traverse = "BFS Traverse result: ";
    private GameObject results;
    public BFS (Material visitedMaterial)
	{
		this.visitedMaterial = visitedMaterial;

	}
		
		
	public BFS ()
	{
	}

	public LinkedList<GraphNode> findPath (GraphNode startNode, GraphNode endNode,bool spanTree)
	{
		
		LinkedList<GraphNode> visitedList = new LinkedList<GraphNode> ();

		Queue<GraphNode> bfsList = new Queue<GraphNode> ();

		bfsList.Enqueue (startNode);
		startNode.Parent = null;

		while (!(bfsList.Count == 0)) {
            GraphNode node = bfsList.Dequeue ();
			Debug.Log (node.NodeValue);

			if ((node.NodeValue == endNode.NodeValue) && (spanTree==false)) {
				return constructPath (node);
			
			} else {
				visitedList.AddLast (node);
				if (!spanTree) {
					node.objReference.GetComponent<MeshRenderer> ().material = visitedMaterial;
				}
				foreach (GraphNode neighbouNode in node.Neighbours) {
					if (!(visitedList.Contains (neighbouNode)) && !(bfsList.Contains (neighbouNode))) {
						neighbouNode.Parent = node;
						node.Edges.Add (neighbouNode);
						bfsList.Enqueue (neighbouNode);
					}
				}

			}
				

		}
			
		foreach (GraphNode n in visitedList) {
            results = GameObject.FindGameObjectWithTag("Result");
            traverse = traverse + n.NodeValue.ToString();
            results.GetComponent<TextMesh>().text = traverse;
            Debug.Log (n.NodeValue + ":");
		}
		return visitedList;
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

}
