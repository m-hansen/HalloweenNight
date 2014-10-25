using UnityEngine;
using System.Collections;

public class DoorbellInteraction : InteractableObject {

	public AudioClip knock;
	public AudioClip speech1;
	public AudioClip speech2;
	public AudioClip speech3;
	public AudioClip doorOpen;

	public float delayForSpeech = 5f;
	public float delayForDoor = 10f;

	private SceneFadeInOut fadeScript;

	// Use this for initialization
	void Start () {

		fadeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneFadeInOut>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate(){
		GameObject.FindGameObjectWithTag ("Interact").GetComponent<PlayerInteraction> ().disableMeshOverride ();

		/*
		 * knock on door then brief pause
		 * speech with a very small pause
		 * door creaks open
		 * 
		 * Fade Out
		 * Load Next Scene
		 * 
		 */

		//Specific order of audio clips that need to be played
		//playAudioClipOneShot(knock);
		//playAudioClipOneShotDelayed(speech, delayForSpeech);
		//playAudioClipOneShotDelayed(doorOpen, delayForSpeech + delayForDoor);

		StartCoroutine("playAudio");

		//FadeOut then load my next scene
		//fadeScript.fadeBlack();


		//LOAD SCENE HERE

	}

	private void playAudioClipOneShot(AudioClip clip){
		
		UnityEngine.Debug.Log("One Shot");
		audio.PlayOneShot(clip);
		
	}

	private IEnumerator playAudio(){

		//Specific order of audio clips that need to be played
		playAudioClipOneShot(knock);

		yield return new WaitForSeconds(delayForSpeech);

		playAudioClipOneShot(speech1);

		yield return new WaitForSeconds(delayForSpeech + speech1.length - 2.5f);

		playAudioClipOneShot(speech2);

		yield return new WaitForSeconds(delayForSpeech +  speech2.length - 2.75f);

		playAudioClipOneShot(speech3);

		yield return new WaitForSeconds(delayForSpeech + speech2.length);
		
		playAudioClipOneShot(doorOpen);
		fadeScript.StartCoroutine ("fadeBlack", .05f);

		yield return new WaitForSeconds(delayForSpeech + 1);
		Application.LoadLevel("House1");
	}
	
}
