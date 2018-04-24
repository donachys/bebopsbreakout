using UnityEngine;

[CreateAssetMenu]
public class Sound : ScriptableObject {
	public AudioClip clip;
	public string soundName;

	public string ToString(){
		return soundName;
	}
}
