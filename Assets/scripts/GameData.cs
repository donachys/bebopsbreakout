using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
	public static GameData gameData;
	public static string CurrentNode = "A";
	public static bool translating = false;
	public static string DestNode = "A";


	public static Hashtable GlobalBools;

	void Awake () {
		if (gameData == null) {
			DontDestroyOnLoad (gameObject);
			gameData = this;
		} else if (gameData != this) {
			Destroy (gameObject);
		}
		GlobalBools = new Hashtable ();
		GlobalBools ["kombucha_appeared"] = false;
		GameData.GlobalBools ["can_exit_tent"] = false;
	}

	void Start() {
		
	}
}
