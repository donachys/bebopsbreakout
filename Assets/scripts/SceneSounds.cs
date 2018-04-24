using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSounds : MonoBehaviour {
	public const int numSoundsInScene = 1;
	public Sound[] sounds = new Sound[numSoundsInScene];

	public Sound getSceneSoundByName(string name){
		foreach (var sound in sounds) {
			if(sound.soundName == name) {
				return sound;
			}
		}
		return null;
	}
}
