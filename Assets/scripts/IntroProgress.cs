using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroProgress : MonoBehaviour {

	public Text textbox;
	private int state = 0;
	public AudioSource src;
	public AudioClip[] clips = new AudioClip[8];
	private string defaultText = "Oh, hello there ...";
	private AudioSource audioSource;
	public AudioClip meowclip;

	void Start () {
		textbox.text = defaultText;
		audioSource = FindObjectOfType<AudioSource> ();
		playSound(state);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Proceed() {
		switch (state){
		case 0:
			//update text
			textbox.text = "Are...are you a cat with thumbs? You might be just who I’m looking for!";
			//play sound
			playSound(state+1);
			state++;
			break;
		case 1:
			textbox.text = "My given name is Bebop...but my friends call me big boppa'... And I’m a cat.";
			playSound(state+1);
			state++;
			break;
		case 2:
			textbox.text = "More specifically, I’m a cat with a penchant for jazz, which might explain my dilemma.";
			playSound(state+1);
			state++;
			break;
		case 3:
			//update text
			textbox.text = "My human, pop-star London La Croix (and world’s worst laser-pointer player), is performing at Floatchella.";
			//play sound
			playSound(state+1);
			state++;
			break;
		case 4:
			textbox.text = "Problem is she brought me with her. Cats at floatchella...ridiculous. It’s well known that cats only listen to jazz.";
			playSound(state+1);
			state++;
			break;
		case 5:
			textbox.text = "So now, I’m trapped...but that’s where you come in.";
			playSound(state+1);
			state++;
			break;
		case 6:
			textbox.text = "The only way to get out of here is to text our way out – and you have thumbs! So if you could help me escape, there’s a ball of catnip in it for you. Ready?";
			playSound(state+1);
			state++;
			break;
		case 7:
			textbox.text = "Wait what? Yes I’m magic! ….but more about that later...right now – I need to get out of here!";
			playSound(state+1);
			state++;
			break;
		case 8:
			textbox.text = "One last thing: try \"help\" if you need assistance! let's go! ";
			playSound(state+1);
			state++;
			break;
		case 9:
			playMeowSound ();
			Application.LoadLevel (2);
			break;
		default:
			textbox.text = defaultText;
			state = 0;
			break;
		}
	}
	private void playSound(int soundNum){
		if (clips [soundNum]) {
			audioSource.clip = clips [soundNum];
			audioSource.Play ();
		}
	}

	private void playMeowSound(){
		audioSource.PlayOneShot(meowclip, 0.75f);
	}
}
