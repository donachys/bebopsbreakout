using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInputHandler : MonoBehaviour {

	public static NodeDefinitions nd;
	private static Inventory inv;
	// Use this for initialization
	void Start () {
		nd = FindObjectOfType<NodeDefinitions>();
		inv = FindObjectOfType<Inventory> ();
	}

	public static string GetResponse(string input){
		string response = "";
		string[] words = input.Split(' ');
		List<string> strippedWords = new List<string> ();
		string received = "";
		foreach (var word in words){
			if (word == "") {
				continue;
			}
			strippedWords.Add (word);
//			Debug.Log(word + (isValidAction(word)? " is valid" : " is invalid") );
		}
		string cmd = string.Join (" ", strippedWords.ToArray ());
		response += (cmd + "\n");
		if (isValidAction (cmd)) {
			switch(cmd){
			case "help":
				return "Usage: command [optional modifier]\n" + "valid commands: \n" + string.Join ("\n", validActions);
				break;
			case "inventory":
				return inv.ToString ();
				break;
			default:
				Dictionary<string, ConditionCollection> temp_ht = nd.nodeDefs [GameData.CurrentNode];

				if (temp_ht.ContainsKey (cmd)) {
					ConditionCollection temp_cc = temp_ht [cmd];
					temp_cc.CheckAndReact ();
				} else {
					response += "I can't do that here right now.";
					Debug.Log ("Dont even know how to " + cmd);
				}
				break;
			}
		} else {
			response += "WAT.";
			Debug.Log("WAT?");
		}

		return response;
	}

	private static string[] validActions = {
		"float [direction]",
		"look",
		"interact",
		"grab",
		"inventory",
		"help"
	};

	private static string[] validHiddenActions = {
		"float right",
		"float left",
		"interact kombucha",
		"look kombucha"
	};

	private static bool isValidAction(string word){
		foreach(var action in validActions){
			if (word == action) {
				return true;
			}
		}
		foreach(var action in validHiddenActions){
			if (word == action) {
				return true;
			}
		}
		return false;
	}
}
