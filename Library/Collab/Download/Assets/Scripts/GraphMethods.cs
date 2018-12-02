using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMethods : MonoBehaviour {
	public GameObject root;
	private IEnumerator DelayTurnOn;
	// Use this for initialization
	void Start () {
		DFS(root.GetComponent<Node>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DFS(Node start)
    {
        start.Mark();
		start.TurnOn();
        foreach (Node child in start.GetNeighbors())
        { 
            if (!child.IsMarked())
            {
                DFS(child);
            }
        }
    }
}
