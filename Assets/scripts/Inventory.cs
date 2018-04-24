using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public const int numItemSlots = 4;
	public Image[] itemImages = new Image[numItemSlots];
	public Item[] items = new Item[numItemSlots];
	public void AddItem(Item itemToAdd)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i] == null)
			{
				items[i] = itemToAdd;
				itemImages[i].sprite = itemToAdd.sprite;
				itemImages[i].enabled = true;
				return;
			}
		}
	}
	public void RemoveItem (Item itemToRemove)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items[i] == itemToRemove)
			{
				items[i] = null;
				itemImages[i].sprite = null;
				itemImages[i].enabled = false;
				return;
			}
		}
	}

	public bool Contains(string itemName){
		foreach(var i in items){
			if (i != null && i.itemName == itemName) {
				return true;
			}
		}
		return false;
	}

	public string ToString(){
		string msg = "";
		foreach(var i in items){
			msg += (i == null) ? "" : i.itemName;
		}
		return msg;
	}
}