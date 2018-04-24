using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {
	public Sprite sprite;
	public string itemName;

	public string ToString(){
		return itemName;
	}
}
