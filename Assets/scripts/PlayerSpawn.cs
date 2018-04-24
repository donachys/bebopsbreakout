using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	public GameObject player;
	private Nodes nodes;
	// Use this for initialization
	void Start () {
		nodes = FindObjectOfType<Nodes> ();
		Vector3 pos = nodes.NodeNameToPos (GameData.CurrentNode);
		GameObject playerClone = (GameObject) Instantiate(player, pos, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
