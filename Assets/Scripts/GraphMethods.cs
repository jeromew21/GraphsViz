using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMethods : MonoBehaviour {
	public GameObject root;
	// Use this for initialization
	void Start () {
		StartCoroutine(Begin()); //Do not touch!!!
	}

	private IEnumerator Begin() { //Everything happens here
		root.GetComponent<GVNode>().SetLabel("Breadth First Search");
		yield return BFS(root.GetComponent<GVNode>());
		root.GetComponent<GVNode>().Clear();
		root.GetComponent<GVNode>().SetLabel("Depth First Search");
		yield return DFS(root.GetComponent<GVNode>(), 0, null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool IsTree(GVNode root) { //is it a tree rooted at root?
		//TODO: Implement
		return false;
	}
 
	bool IsBinTree(GVNode root) { //is it a binary tree?
		if (!IsTree(root)) {
			return false;
		}
		return false;
	}

	public IEnumerator BFS(GVNode start) {
		Queue<GVNode[]> queue = new Queue<GVNode[]>(); //parent, child
		GVNode[] pair = {null, start};
		queue.Enqueue(pair);
		int delay = 0;
		while (queue.Count > 0) {
			GVNode[] curr = queue.Dequeue();
			GVNode node = curr[1];
			GVNode parent = curr[0];
			yield return node.Mark(parent, delay);
			foreach (GVNode child in node.GetNeighbors()) {
				if (!child.IsMarked()) {
					GVNode[] pair2 = {node, child};
					queue.Enqueue(pair2);
				}
			}
			delay += 1;
		}
	}

	public IEnumerator DFS(GVNode start, int depth, GVNode parent)
    {
        yield return start.Mark(parent, depth); //consider making this an animation with parameters of current, or parent
        foreach (GVNode child in start.GetNeighbors())
        { 
            if (!child.IsMarked())
            {
                yield return DFS(child, depth + 1, start);
            }
        }
    }
	
}
