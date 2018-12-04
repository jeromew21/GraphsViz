using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {
	private GameObject originNode;
	private GameObject targetNode;

	public int weight = 1;

	private bool initialized = false;

	public void Initialize(GameObject n1, GameObject n2) {
		originNode = n1;
		targetNode = n2;
		initialized = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (initialized) {
			this.transform.position = (originNode.transform.position + targetNode.transform.position) / 2;
			this.transform.LookAt(originNode.transform);
			this.transform.Rotate(90, 0, 0);
			float size = Vector3.Distance(originNode.transform.position, targetNode.transform.position)/2;
			this.transform.localScale = new Vector3(this.transform.localScale.x, size, this.transform.localScale.z);
		}
	}
}
