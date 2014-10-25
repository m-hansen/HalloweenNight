using UnityEngine;
using System.Collections;

public class CarInteraction1 : InteractableObject {

	public AudioClip openCarDoor;
	public AudioClip closeCarDoor;
	public AudioClip engineStart;
	//public AudioClip radioClick;
	//public AudioClip drivingSounds;
	//public AudioClip creepyMusicBox;
	public AudioSource driving;
	public AudioSource spookyMusic;
	public static bool isDriving = false;
	public GameObject player;

	private Queue audioQueue;
	
	private int timer;
	private SceneFadeInOut fadeScript;

	private int counter;

	// Use this for initialization
	void Start () {
	
		fadeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneFadeInOut>();

		audioQueue = new Queue();
		audioQueue.Enqueue(openCarDoor);
		audioQueue.Enqueue(closeCarDoor);
		audioQueue.Enqueue(engineStart);
		//audioQueue.Enqueue(drivingSounds);
	//	audioQueue.Enqueue(creepyMusicBox);
		isDriving = false;


	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 2) {

			player.transform.position = new Vector3(1069.5f, 42, 1759);
		}
		if (timer == 3) {
			fadeScript.StartCoroutine ("fadeClear", .05f);
			driving.audio.enabled = true;
			spookyMusic.audio.enabled = false;
			isDriving = true;
			}
	}

	public override void Activate (){
		//throw new System.NotImplementedException ();

		fadeScript.StartCoroutine("fadeBlack", .05f);
		GameObject.FindGameObjectWithTag("Interact").GetComponent<PlayerInteraction>().disableMeshOverride();
		counter = audioQueue.Count;
		StartCoroutine("playAudioQueue");

		/*
		 * Finish this so that all the audio plays at the correct timings
		 * 
		 * Open and close door
		 * engine starts
		 * radio clicks on
		 * 
		 * heartbeat audio begins to fade out
		 * 
		 * creepy music box plays on loop
		*/

		//Teleport to different location on map for the infinite road part of the game;

	}

	private IEnumerator playAudioQueue(){


		
		for(int i = 0; i < counter; i++){
			
			AudioClip clipToPlay = audioQueue.Dequeue() as AudioClip;
			float clipLength = clipToPlay.length;
			
			playAudioClipOneShot(clipToPlay);
			timer ++;
			yield return new WaitForSeconds(clipLength);

		}
		
		
		
	}

	private void playAudioClipOneShot(AudioClip clip){

		//UnityEngine.Debug.Log("One Shot");
		audio.PlayOneShot(clip);

	}

	private void playAudioClipContinous(AudioClip clip){

		//UnityEngine.Debug.Log("Continuous");
		audio.clip = clip;
		audio.Play();

	}
}
