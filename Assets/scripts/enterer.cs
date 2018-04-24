using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enterer : MonoBehaviour {
	private Text CmdInputText;
	private string cmdInputTextName = "CurrentCommandText";

	private Text CmdOutputText;
	private string cmdOutputTextName = "CommandOutput";
	private Button btn;
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
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TypeClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TypeClick(){
		string input = CmdInputText.text;
		CmdOutputText.text = "> " + TextInputHandler.GetResponse(input);
		CmdInputText.text = "";
	}
}
