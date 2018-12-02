using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMethods : MonoBehaviour {
	public GameObject root;
	// Use this for initialization
	void Start () {
		StartCoroutine(Begin());
	}

	private IEnumerator Begin() {
		yield return BFS(root.GetComponent<Node>());
		root.GetComponent<Node>().Clear();
		yield return DFS(root.GetComponent<Node>(), 0, null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool IsTree(Node root) { //is it a tree rooted at root?
		//TODO: Implement
		return false;
	}
 
	bool IsBinTree(Node root) { //is it a binary tree?
		if (!IsTree(root)) {
			return false;
		}
		return false;
	}

	public IEnumerator BFS(Node start) {
		Queue<Node[]> queue = new Queue<Node[]>(); //parent, child
		Node[] pair = {null, start};
		queue.Enqueue(pair);
		int delay = 0;
		while (queue.Count > 0) {
			Node[] curr = queue.Dequeue();
			Node node = curr[1];
			Node parent = curr[0];
			yield return node.Mark(parent, delay);
			foreach (Node child in node.GetNeighbors()) {
				if (!child.IsMarked()) {
					Node[] pair2 = {node, child};
					queue.Enqueue(pair2);
				}
			}
			delay += 1;
		}
	}

	public IEnumerator DFS(Node start, int depth, Node parent)
    {
        yield return start.Mark(parent, depth); //consider making this an animation with parameters of current, or parent
        foreach (Node child in start.GetNeighbors())
        { 
            if (!child.IsMarked())
            {
                yield return DFS(child, depth + 1, start);
            }
        }
    }
	
}
