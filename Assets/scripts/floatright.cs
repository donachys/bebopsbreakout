using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatright : MonoBehaviour {
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temppos = transform.position;
		transform.position = new Vector3(temppos.x - (speed), temppos.y, temppos.z);
	}
}
