using UnityEngine;

public class InstantiateReaction : Reaction {
	public Vector3 pos;
	public GameObject prefab;

	protected override void ImmediateReaction(){
		GameObject go = (GameObject) Instantiate(prefab, pos, Quaternion.identity);

	}
}
