using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class DistantPhoneAudio : MonoBehaviour {

	public AudioClip cop1Part1;
	public AudioClip cop2Part1;
	public AudioClip cop1Part2;
	public AudioClip cop1Part3;
	public AudioClip gunshot;
	public AudioClip monsterScream;
	public AudioClip bodyThrown;

	private Queue audioQueue;

	private PhoneInteraction piScript;

	private int counter;


	void OnEnable(){

		piScript = GetComponentInParent<PhoneInteraction>();

		counter = audioQueue.Count;
		StartCoroutine("playAudioQueue");

	}

	// Use this for initialization
	void Awake () {



		//Lazy way of adding all these
		audioQueue = new Queue();
		audioQueue.Enqueue(cop1Part1);
		audioQueue.Enqueue(cop2Part1);
		audioQueue.Enqueue(cop1Part2);
		audioQueue.Enqueue(cop1Part3);
		audioQueue.Enqueue(gunshot);
		audioQueue.Enqueue(monsterScream);
		audioQueue.Enqueue(bodyThrown);


	}

	private IEnumerator playAudioQueue(){

		for(int i = 0; i < counter; i++){

			AudioClip clipToPlay = audioQueue.Dequeue() as AudioClip;
			float clipLength = clipToPlay.length;


			if(clipToPlay.name.Contains("Gun Shot")){
				
				playGunAudio(clipToPlay);
				
			}else{
				playAudioClip(clipToPlay);
			}

			yield return new WaitForSeconds(clipLength);

			if(audioQueue.Count == 0){
				piScript.resumeAudio();
				this.enabled = false;
			}
		}

	}

	private IEnumerator gunShots(AudioClip clip){

		audio.PlayOneShot(clip);

		yield return new WaitForSeconds(2f);

		for(int i=0;i<2;i++){
			audio.PlayOneShot(clip);

			yield return new WaitForSeconds(.5f);
		}

		audio.PlayOneShot(clip);
	}

	private void playGunAudio(AudioClip clip){

		StartCoroutine("gunShots", clip);

	}

	private void playAudioClip(AudioClip clip){

		//audio.Stop();
		
		audio.loop = false;
		audio.PlayOneShot(clip);

	}
}
