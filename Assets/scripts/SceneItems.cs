using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItems : MonoBehaviour {
	public const int numItemsInScene = 4;
	public Item[] items = new Item[numItemsInScene];
	// Use this for initialization
	void Start () {
		
	}
	public Item getSceneItemByName(string name){
		foreach (var item in items) {
			if(item.itemName == name) {
				return item;
			}
		}
		return null;
	}
}
