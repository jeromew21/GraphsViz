using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	public List<GameObject> neighbors;
	private bool isMarked;

	public GameObject edgePrefab;

	public GameObject dropPrefab;

	public Material defaultMaterial;

	public Material markedMaterial;

	private bool clicked = false;

	void MakeConnections() {
		Vector3 currPos = this.transform.position;

		foreach (GameObject neighbor in neighbors) {
			Vector3 neighborPos = neighbor.transform.position;
			Edge edge = Instantiate(
				edgePrefab, 
				(currPos + neighborPos)/2, 
				Quaternion.identity
			).GetComponent<Edge>();
			edge.Initialize(this.gameObject, neighbor);
		}
	}

	// Use this for initialization
	void Start() {
		isMarked = false;
		MakeConnections();
		GetComponent("Halo").enabled = false;
	}

	public void Mark() { //Possibly overload with parent argument
 		isMarked = true;
	}

	public void Clear() {
		isMarked = false;
		TurnOff();
		foreach (Node k in GetNeighbors()) {
			if (k.IsMarked()) {
				k.Clear();
			}
		}
	}

	public IEnumerator Mark(Node parent, float delay) {
		isMarked = true;
		if (parent != null) {
			GameObject drop = Instantiate(dropPrefab, gameObject.transform);
			Vector3 t0 = parent.transform.position;
			drop.transform.position = t0;
			yield return MakeTurnOnAnimation(drop, t0, gameObject.transform.position, delay);
		} else {
			yield return DelayTurnOn(delay);
		}
	}

	private IEnumerator MakeTurnOnAnimation(GameObject drop, Vector3 t0, Vector3 t1, float delay) {
		//yield return new WaitForSeconds(delay/2);
		for (float k = 0; k < 1; k += 0.01f) {
			yield return new WaitForSeconds(0.01f);
			drop.transform.position = Vector3.Lerp(t0, t1, k);
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

	public List<Node> GetNeighbors() {
		List<Node> result = new List<Node>();
		foreach (GameObject neighbor in neighbors) {
			result.Add(neighbor.GetComponent<Node>());
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
