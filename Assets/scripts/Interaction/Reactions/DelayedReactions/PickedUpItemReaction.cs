using UnityEngine;
public class PickedUpItemReaction : DelayedReaction
{
    public Item item;               // The item asset to be added to the Inventory.


    private Inventory inventory;    // Reference to the Inventory component.


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory>();
		Debug.Log ("specific init inv: " + inventory);
    }


    protected override void ImmediateReaction()
    {
		Debug.Log ("inv: " + inventory);
        inventory.AddItem(item);
    }
}
