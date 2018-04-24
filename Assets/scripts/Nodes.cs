using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour {

	public Nodes nodes;
	public GameObject[] nodeData;
	// Use this for initialization
	void Start () {
		if (nodes == null) {
			DontDestroyOnLoad (gameObject);
			nodes = this;
		} else if (nodes != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 NodeNameToPos(string name){
		foreach (var node in nodeData){
			if (node.name == name) {
				return node.transform.position;
			}
		}
		return new Vector3 ();
	}

	public GameObject GetNode(string name){
		foreach (var go in nodeData){
			if (go.name == name) {
				return go;
			}
		}
		return new GameObject ();
	}
}
