using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GVNode : MonoBehaviour {
	public List<GameObject> neighbors;

	private List<GameObject> edges;
	private bool isMarked;

	public GameObject edgePrefab;

	public GameObject dropPrefab;

	public GameObject nodePrefab;

	public Material defaultMaterial;

	public Material markedMaterial;

	private bool clicked = false;

	private GameObject label;
 

	public void MakeConnections() {
		Vector3 currPos = this.transform.position;
		foreach (GameObject e in edges) {
			Destroy(e);
		}
		edges = new List<GameObject>();
		foreach (GameObject neighbor in neighbors) {
			Vector3 neighborPos = neighbor.transform.position;
			GameObject edgeObject = Instantiate(
				edgePrefab, 
				(currPos + neighborPos)/2, 
				Quaternion.identity
			);
			Edge edge = edgeObject.GetComponent<Edge>();
			edge.Initialize(this.gameObject, neighbor);
			edges.Add(edgeObject);
		}
	}
    

	public void CreateNewNeighbor(Vector3 pos) {
		GameObject g = Instantiate(nodePrefab, gameObject.transform);
		g.transform.position = pos;
		AddNeighbor(g);
		MakeConnections();
	}

	public void AddNeighbor(GameObject n) {
		if (n.GetComponent<GVNode>() == null) {
			Debug.Log("A gameobject without a node component was linked to a node.");
			return;
		}
		neighbors.Add(n);
	}

	public void SetLabel(string s) {
		label.active = true;
		label.GetComponent<TextMesh>().text = s;
	}

	// Use this for initialization
	void Start() {
		label = transform.GetChild(0).gameObject;
		label.active = false;
		isMarked = false;
		edges = new List<GameObject>();
        neighbors = new List<GameObject>();
		//MakeConnections();
	}

	public void Mark() { //Possibly overload with parent argument
 		isMarked = true;
	}

	public void Clear() {
		isMarked = false;
		TurnOff();
		foreach (GVNode k in GetNeighbors()) {
			if (k.IsMarked()) {
				k.Clear();
			}
		}
	}

	public IEnumerator Mark(GVNode parent, float delay) {
		isMarked = true;
		if (parent != null) {
			GameObject drop = Instantiate(dropPrefab, gameObject.transform);
			Vector3 t0 = parent.transform.position;
			drop.transform.position = t0;
			yield return MakeTurnOnAnimation(drop, t0, gameObject, delay);
		} else {
			yield return DelayTurnOn(delay);
		}
	}

	private IEnumerator MakeTurnOnAnimation(GameObject drop, Vector3 t0, GameObject t1, float delay) {
		//yield return new WaitForSeconds(delay/2);
		for (float k = 0; k < 1; k += 0.01f) {
			yield return new WaitForSeconds(0.01f);
			drop.transform.position = Vector3.Lerp(t0, t1.transform.position, k);
		}
		TurnOn();
	}

	public void Unmark() {
		isMarked = false;
	}

	public int NumNeigbors() {
		return neighbors.Count;
	}

	public bool IsMarked() {
		return isMarked;
	}

	public void TurnOn() {
		gameObject.GetComponent<Renderer>().material = markedMaterial;
	}

	public void TurnOff() {
		gameObject.GetComponent<Renderer>().material = defaultMaterial;
	}

	public List<GVNode> GetNeighbors() {
		List<GVNode> result = new List<GVNode>();
		foreach (GameObject neighbor in neighbors) {
			result.Add(neighbor.GetComponent<GVNode>());
		}
		return result;
	}

	private IEnumerator DelayTurnOn(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
		TurnOn();
    }
	
	/* Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			clicked = true;
		}
		if (clicked) {
			neighbors.Add()
		}
	}
	void OnMouseDown() */
}
