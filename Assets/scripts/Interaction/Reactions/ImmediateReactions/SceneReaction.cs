using UnityEngine;

public class SceneReaction : Reaction {
	public int toLoad;
	public int delay;

	protected override void ImmediateReaction(){
		Application.LoadLevel (toLoad);
	}
}
