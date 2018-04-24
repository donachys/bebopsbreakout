using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveReaction : Reaction {

	public string destination;

	protected override void ImmediateReaction () {
		Debug.Log ("immediate reaction called on movereaction");
		GameData.DestNode = destination;
		GameData.translating = true;
	}
}
