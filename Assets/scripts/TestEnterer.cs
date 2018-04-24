using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestEnterer : MonoBehaviour {
	private Text CmdInputText;
	private string cmdInputTextName = "CurrentCommandText";

	private Text CmdOutputText;
	private string cmdOutputTextName = "CommandOutput";
	private Text thisText;
	private InputField thisInput;
	// Use this for initialization
	void Start () {
		var foundObjects = FindObjectsOfType<Text>();
		for (int i = 0; i < foundObjects.Length; i++) {
			if (foundObjects [i].name == cmdOutputTextName) {
				CmdOutputText = foundObjects [i];
				continue;
			}
			if (foundObjects [i].name == cmdInputTextName) {
				CmdInputText = foundObjects [i];
				continue;
			}
			if (CmdInputText != null && CmdOutputText != null) {
				break;
			}
		}
		thisInput = this.GetComponent<InputField> ();
		thisText = thisInput.GetComponentInChildren<Text> ();
		thisInput.onEndEdit.AddListener (submitPress);
	}

	// Update is called once per frame
	void Update () {

	}
	public void submitPress(string input){
		Debug.Log ("input:" + input);
		CmdInputText.text = "";
		CmdOutputText.text = "> " + TextInputHandler.GetResponse(input);
		thisText.text = "";
	}
}
