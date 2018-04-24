using UnityEngine;

public class UninstantiateReaction : Reaction {
	public string objectName;

	protected override void ImmediateReaction(){
		GameObject[] gos = FindObjectsOfType<GameObject> ();
		foreach (var go in gos) {
			if (go.name == objectName + "(Clone)") {
				Destroy (go);
			}
		}
	}
}
