using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float playerSpeed=0.75f;
	private Nodes nodes;
	private float traveltime;
	private float minDist = 100f;

	// Use this for initialization
	void Start () {
		nodes = FindObjectOfType<Nodes> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("translating is: " + GameData.translating);
		if (GameData.translating) {
			traveltime += Time.deltaTime;
			Vector3 dest = nodes.NodeNameToPos (GameData.DestNode);
			Vector3 start = nodes.NodeNameToPos (GameData.CurrentNode);
//			Debug.Log ("dist is: " + Vector3.Distance (transform.position, dest));
			if (Vector3.Distance(transform.position, dest) <= minDist) {
//				Debug.Log ("min dist achieved");
				transform.position = dest;
				traveltime = 0f;
				GameData.translating = false;
				GameData.CurrentNode = GameData.DestNode;

			} else {
//				Debug.Log ("min dist not achieved");
				transform.position = new Vector3 (
					Mathf.Lerp (start.x, dest.x, traveltime * playerSpeed),
					Mathf.Lerp (start.y, dest.y, traveltime * playerSpeed),
					0
				);	
			}
		}
//		Debug.Log (traveltime);
	}
}
