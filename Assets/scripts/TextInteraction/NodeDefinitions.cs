using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDefinitions : MonoBehaviour {
	
	public string name;
	public static Nodes nodes;
	private static Inventory inv;

	public Dictionary<string, Dictionary<string, ConditionCollection>> nodeDefs;// string name -> string command -> ConditionCollection -> condition -> reactionlist -> reaction
	public static bool testbool = true;
	// Use this for initialization
	void Awake () {
		
	}

	void Start() {
		nodes = FindObjectOfType<Nodes> ();
		inv = FindObjectOfType<Inventory> ();

		nodeDefs = getDefs ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private static Dictionary<string, Dictionary<string, ConditionCollection>> getDefs() {
		Dictionary<string, Dictionary<string, ConditionCollection>> ht = new Dictionary<string, Dictionary<string, ConditionCollection>>();

		ht.Add ("A", nodeA());
		ht.Add ("B", nodeB());
		ht.Add ("C", nodeC());

		return ht;
	}

	public static Dictionary<string, ConditionCollection> nodeA(){
		GameObject nodeAgo = nodes.GetNode ("A");
		SceneSounds ss = FindObjectOfType<SceneSounds> ();

		AudioReaction whoosh_sound = new AudioReaction ();
		whoosh_sound.audioSource = nodeAgo.GetComponent<AudioSource>() as AudioSource;
		whoosh_sound.audioClip = ss.getSceneSoundByName ("movewhoosh").clip;
		whoosh_sound.delay = 0.0f;

		//float right
		ConditionCollection cc = new ConditionCollection();
		ReactionCollection temp_react_collection = new ReactionCollection ();
		MoveReaction temp_react = new MoveReaction();
		temp_react.destination = "B";
		temp_react_collection.reactions = new Reaction[] {
			temp_react,
			whoosh_sound
		};
		cc.reactionCollection = temp_react_collection;
		Condition temp_cond = new Condition ();
		temp_cond.toEval = () => {
			return true;
		};
		cc.requiredConditions = new Condition[]{
			temp_cond
		};

		//float left
		ConditionCollection floatleftcc = new ConditionCollection();
		ReactionCollection floatleft_react_collection = new ReactionCollection ();
		ReactionCollection floatleft_negreact_collection = new ReactionCollection ();

		PlayerTextReaction floatleft_react = new PlayerTextReaction();
		floatleft_react.message = "I'm outta here.";
		floatleft_react.delay = 0f;

		SceneReaction win_reaction = new SceneReaction ();
		win_reaction.delay = 0;
		win_reaction.toLoad = 3;

		floatleft_react_collection.reactions = new Reaction[] {
			floatleft_react,
			win_reaction
		};

		PlayerTextReaction floatleft_neg_react = new PlayerTextReaction();
		floatleft_neg_react.message = "I can't get out ... London La Croix will see.";
		floatleft_neg_react.delay = 0f;


		AudioReaction nooutside_react_sound = new AudioReaction ();
		nooutside_react_sound.audioSource = nodeAgo.GetComponent<AudioSource>() as AudioSource;
		nooutside_react_sound.audioClip = ss.getSceneSoundByName ("nooutside").clip;
		nooutside_react_sound.delay = 0.0f;

		floatleft_negreact_collection.reactions = new Reaction[] {
			floatleft_neg_react,
			nooutside_react_sound
		};

		floatleftcc.reactionCollection = floatleft_react_collection;
		floatleftcc.negReactionCollection = floatleft_negreact_collection;
		Condition floatleft_cond = new Condition ();
		floatleft_cond.toEval = () => {
			return (bool)GameData.GlobalBools["can_exit_tent"];
		};
		floatleftcc.requiredConditions = new Condition[]{
			floatleft_cond
		};
		floatleftcc.reactionCollection.DoInit ();
		floatleftcc.negReactionCollection.DoInit ();

		//look
		ConditionCollection cclook = new ConditionCollection ();
		ReactionCollection look_react_collection = new ReactionCollection ();

		PlayerTextReaction look_react = new PlayerTextReaction();
		look_react.message = "UGH! this music... gotta break out of here.";
		look_react.delay = 0.0f;

		AudioReaction concert_react_sound = new AudioReaction ();
		concert_react_sound.audioSource = nodeAgo.GetComponent<AudioSource>() as AudioSource;
		concert_react_sound.audioClip = ss.getSceneSoundByName ("concert").clip;
		concert_react_sound.delay = 0.0f;

		look_react_collection.reactions = new Reaction[] {
			look_react,
			concert_react_sound
		};

		Condition always_true_cond = new Condition ();
		always_true_cond.toEval = () => {
			return true;
		};

		cclook.reactionCollection = look_react_collection;
		cclook.requiredConditions = new Condition[]{
			always_true_cond
		};
		cclook.reactionCollection.DoInit ();

		Dictionary<string, ConditionCollection> htm = new Dictionary<string, ConditionCollection>();
		htm.Add ("float right", cc);
		htm.Add ("float left", floatleftcc);
		htm.Add ("look", cclook);
		return htm;
	}

	public static Dictionary<string, ConditionCollection> nodeB(){
		GameObject nodeBgo = nodes.GetNode ("B");
		SceneSounds ss = FindObjectOfType<SceneSounds> ();

		AudioReaction whoosh_sound = new AudioReaction ();
		whoosh_sound.audioSource = nodeBgo.GetComponent<AudioSource>() as AudioSource;
		whoosh_sound.audioClip = ss.getSceneSoundByName ("movewhoosh").clip;
		whoosh_sound.delay = 0.0f;

		//float left
		ConditionCollection ccfloatleft = new ConditionCollection();
		ReactionCollection floatleft_react_collection = new ReactionCollection ();
		MoveReaction floatleft_react = new MoveReaction();
		floatleft_react.destination = "A";
		floatleft_react_collection.reactions = new Reaction[] {
			floatleft_react,
			whoosh_sound
		};
		ccfloatleft.reactionCollection = floatleft_react_collection;
		Condition always_true_cond = new Condition ();
		always_true_cond.toEval = () => {
			return true;
		};
		ccfloatleft.requiredConditions = new Condition[]{
			always_true_cond
		};
		//float right
		ConditionCollection ccfloatright = new ConditionCollection();
		ReactionCollection floatright_react_collection = new ReactionCollection ();

		MoveReaction floatright_react = new MoveReaction();
		floatright_react.destination = "C";
		floatright_react_collection.reactions = new Reaction[] {
			floatright_react,
			whoosh_sound
		};

		ccfloatright.reactionCollection = floatright_react_collection;
		ccfloatright.requiredConditions = new Condition[]{
			always_true_cond
		};

		//kombucha conditions
		Condition kombucha_not_appeared = new Condition ();
		kombucha_not_appeared.toEval = () => {
			return !((bool)GameData.GlobalBools["kombucha_appeared"]);
		};

		Condition kombucha_appeared = new Condition ();
		kombucha_appeared.toEval = () => {
			return ((bool)GameData.GlobalBools["kombucha_appeared"]);
		};

		//grab
		ConditionCollection ccgrab = new ConditionCollection();
		ReactionCollection grab_react_collection = new ReactionCollection ();

		InstantiateReaction grab_react = new InstantiateReaction ();
		grab_react.prefab = Resources.Load<GameObject> ("Prefabs/Kombucha");
		grab_react.pos = new Vector3 (5200, 350, 0);

		GlobalBoolReaction kombucha_appeared_reaction = new GlobalBoolReaction ();
		kombucha_appeared_reaction.toSet = "kombucha_appeared";
		kombucha_appeared_reaction.setTo = true;


		AudioReaction kombucha_appeared_react_sound = new AudioReaction ();
		kombucha_appeared_react_sound.audioSource = nodeBgo.GetComponent<AudioSource>() as AudioSource;
		kombucha_appeared_react_sound.audioClip = ss.getSceneSoundByName ("oww").clip;
		kombucha_appeared_react_sound.delay = 0.0f;

		grab_react_collection.reactions = new Reaction[] {
			grab_react,
			kombucha_appeared_reaction,
			kombucha_appeared_react_sound
		};

		ccgrab.reactionCollection = grab_react_collection;
		ccgrab.requiredConditions = new Condition[]{
			kombucha_not_appeared
		};

		ccgrab.reactionCollection.DoInit ();

		//look kombucha
		ConditionCollection cclookk = new ConditionCollection ();
		ReactionCollection lookk_react_collection = new ReactionCollection ();
		PlayerTextReaction lookk_react = new PlayerTextReaction();
		lookk_react.message = "My human drinks a lot of kombucha.";
		lookk_react.delay = 0f;

		lookk_react_collection.reactions = new Reaction[] {
			lookk_react
		};

		cclookk.reactionCollection = lookk_react_collection;
		cclookk.requiredConditions = new Condition[]{
			kombucha_appeared
		};
		cclookk.reactionCollection.DoInit ();

		//look
		ConditionCollection cclook = new ConditionCollection ();
		ReactionCollection look_react_collection = new ReactionCollection ();
		ReactionCollection look_neg_react_collection = new ReactionCollection ();

		PlayerTextReaction look_react = new PlayerTextReaction();
		look_react.message = "kombucha, gross.";
		look_react.delay = 0f;

		PlayerTextReaction look_neg_react = new PlayerTextReaction();
		look_neg_react.message = "meeeow...if only there was a way to distract her!";
		look_neg_react.delay = 0f;

		look_react_collection.reactions = new Reaction[] {
			look_react
		};
		look_neg_react_collection.reactions = new Reaction[] {
			look_neg_react
		};

		cclook.reactionCollection = look_react_collection;
		cclook.negReactionCollection = look_neg_react_collection;
		cclook.requiredConditions = new Condition[]{
			kombucha_appeared //TODO: bey is gone?
		};
		cclook.reactionCollection.DoInit ();
		cclook.negReactionCollection.DoInit ();

		//interact kombucha
		ConditionCollection ccinteractk = new ConditionCollection();
		ReactionCollection interactk_react_collection = new ReactionCollection ();
		GameObjectReaction interactk_go_reaction = new GameObjectReaction ();

		GameObject[] gos = FindObjectsOfType<GameObject> ();
		foreach (var g in gos){
			if (g.name == "Bey") {
				interactk_go_reaction.gameObject = g;
				break;
			}
		}
		interactk_go_reaction.activeState = false;

		GlobalBoolReaction can_exit_tent_reaction = new GlobalBoolReaction ();
		can_exit_tent_reaction.toSet = "can_exit_tent";
		can_exit_tent_reaction.setTo = true;

		UninstantiateReaction uninstantiate_kombucha_reaction = new UninstantiateReaction ();
		uninstantiate_kombucha_reaction.objectName = "kombucha";

		AudioReaction kombucha_drugged_react_sound = new AudioReaction ();
		kombucha_drugged_react_sound.audioSource = nodeBgo.GetComponent<AudioSource>() as AudioSource;
		kombucha_drugged_react_sound.audioClip = ss.getSceneSoundByName ("drugged_the_human").clip;
		kombucha_drugged_react_sound.delay = 0.0f;

		Condition pills_acquired = new Condition ();
		pills_acquired.toEval = () => {
			return inv.Contains("pills");
		};

		LostItemReaction pill_loss_react = new LostItemReaction ();
		SceneItems si = FindObjectOfType<SceneItems> ();
		pill_loss_react.item = si.getSceneItemByName ("pills");

		interactk_react_collection.reactions = new Reaction[] {
			interactk_go_reaction,
			pill_loss_react,
			can_exit_tent_reaction,
			uninstantiate_kombucha_reaction,
			kombucha_drugged_react_sound
		};

		ccinteractk.reactionCollection = interactk_react_collection;
		ccinteractk.requiredConditions = new Condition[]{
			pills_acquired,
			kombucha_appeared
		};

		ccinteractk.reactionCollection.DoInit ();


		Dictionary<string, ConditionCollection> htm = new Dictionary<string, ConditionCollection>();
		htm.Add ("float left", ccfloatleft);
		htm.Add ("float right", ccfloatright);
		htm.Add ("grab", ccgrab);
		htm.Add ("look kombucha", cclookk);
		htm.Add ("look", cclook);
		htm.Add ("interact kombucha", ccinteractk);
		return htm;
	}

	public static Dictionary<string, ConditionCollection> nodeC(){
		GameObject nodeCgo = nodes.GetNode ("C");
		SceneSounds ss = FindObjectOfType<SceneSounds> ();

		AudioReaction whoosh_sound = new AudioReaction ();
		whoosh_sound.audioSource = nodeCgo.GetComponent<AudioSource>() as AudioSource;
		whoosh_sound.audioClip = ss.getSceneSoundByName ("movewhoosh").clip;
		whoosh_sound.delay = 0.0f;

		//float left
		ConditionCollection ccfloatleft = new ConditionCollection();
		ReactionCollection floatleft_react_collection = new ReactionCollection ();
		MoveReaction floatleft_react = new MoveReaction();
		floatleft_react.destination = "B";
		floatleft_react_collection.reactions = new Reaction[] {
			floatleft_react,
			whoosh_sound
		};
		ccfloatleft.reactionCollection = floatleft_react_collection;
		Condition always_true_cond = new Condition ();
		always_true_cond.toEval = () => {
			return true;
		};
		ccfloatleft.requiredConditions = new Condition[]{
			always_true_cond
		};

		//float right
		ConditionCollection ccfloatright = new ConditionCollection();
		ReactionCollection floatright_react_collection = new ReactionCollection ();
		PlayerTextReaction floatright_react = new PlayerTextReaction();
		floatright_react.message = "There is nothing to the right.";
		//		floatright_react.textColor = Color.white;
		floatright_react.delay = 0.01f;
		AudioReaction floatright_react_sound = new AudioReaction ();
		floatright_react_sound.audioSource = nodeCgo.GetComponent<AudioSource>() as AudioSource;
		floatright_react_sound.audioClip = ss.getSceneSoundByName ("meow1").clip;
		floatright_react_sound.delay = 0.0f;
		floatright_react_collection.reactions = new Reaction[] {
			floatright_react,
			floatright_react_sound
		};
		Condition always_true_init_cond = new Condition ();
		always_true_init_cond.toEval = () => {
			ccfloatright.reactionCollection.DoInit ();
			return true;
		};
		ccfloatright.reactionCollection = floatright_react_collection;
		ccfloatright.requiredConditions = new Condition[] {
			always_true_init_cond
		};

		//grab
		ConditionCollection ccgrab = new ConditionCollection ();
		ReactionCollection grab_react_collection = new ReactionCollection ();
		PickedUpItemReaction grab_react = new PickedUpItemReaction ();
		SceneItems si = FindObjectOfType<SceneItems> ();
		grab_react.item = si.getSceneItemByName ("pills");

		GameObjectReaction grab_pills_react = new GameObjectReaction ();
		GameObject[] gos = FindObjectsOfType<GameObject> ();
		foreach (var g in gos){
			if (g.name == "pills") {
				grab_pills_react.gameObject = g;
				break;
			}
		}
		grab_pills_react.activeState = false;

		AudioReaction grab_pills_react_sound = new AudioReaction ();
		grab_pills_react_sound.audioSource = nodeCgo.GetComponent<AudioSource>() as AudioSource;
		grab_pills_react_sound.audioClip = ss.getSceneSoundByName ("pills").clip;
		grab_pills_react_sound.delay = 0.0f;

		grab_react_collection.reactions = new Reaction[] {
			grab_react,
			grab_pills_react,
			grab_pills_react_sound
		};

		Condition pills_not_yet_acquired = new Condition ();
		pills_not_yet_acquired.toEval = () => {
			return !inv.Contains("pills");
		};
	
		ccgrab.reactionCollection = grab_react_collection;
		ccgrab.requiredConditions = new Condition[] {
			pills_not_yet_acquired
		};
		ccgrab.reactionCollection.DoInit ();

		//look
		ConditionCollection cclook = new ConditionCollection ();
		ReactionCollection look_react_collection = new ReactionCollection ();
		PlayerTextReaction look_react = new PlayerTextReaction();
		look_react.message = "My human’s happy pills, fun to bat under the couch.";
		//		floatright_react.textColor = Color.white;
		look_react.delay = 0.01f;

		look_react_collection.reactions = new Reaction[] {
			look_react
		};

		cclook.reactionCollection = look_react_collection;
		cclook.requiredConditions = new Condition[]{
			pills_not_yet_acquired
		};
		cclook.reactionCollection.DoInit ();

		//interact
		ConditionCollection ccinteract = new ConditionCollection ();
		ReactionCollection interact_react_collection = new ReactionCollection ();

		PlayerTextReaction interact_ptext_react = new PlayerTextReaction();
		interact_ptext_react.message = "meow...pills are for humans, not magic cats!";
		interact_ptext_react.delay = 0f;

		interact_react_collection.reactions = new Reaction[] {
			interact_ptext_react
		};
		Condition cannot_exit_cond = new Condition ();
		cannot_exit_cond.toEval = () => {
			return !(bool)GameData.GlobalBools["can_exit_tent"];
		};
		ccinteract.reactionCollection = interact_react_collection;
		cclook.requiredConditions = new Condition[] {
			pills_not_yet_acquired,
			cannot_exit_cond
		};
		ccinteract.reactionCollection.DoInit ();

		Dictionary<string, ConditionCollection> htm = new Dictionary<string, ConditionCollection>();
		htm.Add ("float left", ccfloatleft);
		htm.Add ("float right", ccfloatright);
		htm.Add ("grab", ccgrab);
		htm.Add ("look", cclook);
		htm.Add ("interact", ccinteract);

		return htm;
	}
}
