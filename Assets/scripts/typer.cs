using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typer : MonoBehaviour {

	private Text CmdInputText;
	private string cmdInputTextName = "CurrentCommandText";
	private Button btn;

	// Use this for initialization
	void Start () {
		var foundObjects = FindObjectsOfType<Text>();
		for (int i = 0; i < foundObjects.Length; i++) {
			if (foundObjects [i].name == cmdInputTextName) {
				CmdInputText = foundObjects [i];
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
		if (CmdInputText.text == "> your command") {
			CmdInputText.text = "";
		}
		string txt = CmdInputText.text;
		if (txt.Length > 100) {
			txt = txt.Substring (btn.name.Length);	
		} else {
			txt = txt + btn.name;
		}
		CmdInputText.text = txt;
	}
}
