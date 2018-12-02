using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMethods : MonoBehaviour {
	public GameObject root;
	// Use this for initialization
	void Start () {
		DFS(root.GetComponent<Node>(), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool IsTree() { //is it a tree rooted at root?
		//TODO: Implement
		return false;
	}
 
	bool IsBinTree() { //is it a binary tree?
		if (!IsTree()) {
			return false;
		}
		return false;
	}

	public void DFS(Node start, int depth)
    {
        start.Mark(); //consider making this an animation with parameters of current node
		StartCoroutine(DelaySingleTurnOn((float) depth, start));
        foreach (Node child in start.GetNeighbors())
        { 
            if (!child.IsMarked())
            {
                DFS(child, depth + 1);
            }
        }
    }
	private IEnumerator DelaySingleTurnOn(float waitTime, Node node)
    {
		yield return new WaitForSeconds(waitTime);
		node.TurnOn();
    }
}
