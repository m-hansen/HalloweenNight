using UnityEngine;
using System.Collections;

public class PhoneInteraction : InteractableObject {

	public GameObject distantAudio;
	public HouseGhoulMoans ghoulMoanScript;
	public ChaosGhoulSpawner chaosScript;
	public ScaredAudio scaryAudioScript;
	public LeaveInteraction leaveScript;

	public AudioSource playerSource;

	//Audio clips for the phone call
	public AudioClip ringing;
	public AudioClip copPhone1;
	public AudioClip copPhone2;
	public AudioClip lightFlicker;
	public AudioClip playerPhone;
	public AudioClip copCommingIn;

	//Audio clips for after the phone call while still in the same room
	public AudioClip playerHelloOfficer;
	public AudioClip monsterLaugh;
	public AudioClip playerKiddingMe;
	public AudioClip playerDoorOpen;

	private Queue audioQueue1;
	private Queue audioQueue2;

	private GameObject lightFlick;
	private FlickeringLights lightFlickScript;

	// Use this for initialization
	void Start () {

		//Get a refrence to the heartbeat audio clip here

		lightFlick = GameObject.FindGameObjectWithTag("LightFlicker");
		lightFlickScript = lightFlick.GetComponent<FlickeringLights>();

		audioQueue1 = new Queue();
		audioQueue2 = new Queue();

		audioQueue1.Enqueue(copPhone1);
		audioQueue1.Enqueue(copPhone2);
		audioQueue1.Enqueue(lightFlicker);
		audioQueue1.Enqueue(playerPhone);
		audioQueue1.Enqueue(copCommingIn);


		audioQueue2.Enqueue(playerHelloOfficer);
		audioQueue2.Enqueue(monsterLaugh);
		audioQueue2.Enqueue(playerKiddingMe);
		audioQueue2.Enqueue(playerDoorOpen);


	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void resumeAudio(){

		//Play the remaining audio clips here
		StartCoroutine("playAudioQueue2");

	}

	public override void Activate(){

		//Layout for this script

		/*
		 *Phone is already ringing
		 *CopPhone plays
		 *One Shot lightFlicker audio
		 *	tone down heartbeat here
		 *copPhone Continues
		 *One Shot playerPhone
		 *One Shot copOnMyWay
		 *
		 *Activate the door slamming script and pause self;
		 *
		 *Resume after the other audio has finished
		 *OneShot playerHelloOffice
		 *OneShot monsterLaugh
		 *OneShot lightsFlicker
		 *	increase sound of heartbeat
		 *OneShot playerKiddingMe
		 * 
		 */

		StartCoroutine("playAudioQueue1");
		GameObject.FindGameObjectWithTag("Interact").GetComponent<PlayerInteraction>().disableMeshOverride();



	}

	private IEnumerator playAudioQueue1(){
		
		while(audioQueue1.Count != 0){
			
			AudioClip clipToPlay = audioQueue1.Dequeue() as AudioClip;
			float clipLength = clipToPlay.length;

			//Make this louder like you are saying it directly
			//Dont forget to add to audioqueue2
			if(clipToPlay.name.Contains("Player")){

				playerSource.PlayOneShot(clipToPlay, .6f);

			}else{
				playAudioClipOneShot(clipToPlay);
			}

			//Make this only run once
			if(ghoulMoanScript.getPhoneStatus() == true){
				StartCoroutine("onPhone", (clipLength + (audioQueue1.Peek() as AudioClip).length));
			}

			//Make the lights flicker off here
			if(lightFlickScript.getObjectToFlickerStatus() == false){
				lightFlickScript.flickerOn(clipLength + (audioQueue1.Peek() as AudioClip).length);
			}
			
			yield return new WaitForSeconds(clipLength);
		}

		distantAudio.SetActive(true);
		
	}

	private IEnumerator playAudioQueue2(){
		
		while(audioQueue2.Count != 0){
			
			AudioClip clipToPlay = audioQueue2.Dequeue() as AudioClip;
			float clipLength = clipToPlay.length;

			if(clipToPlay.name.Contains("Player")){
				
				playerSource.PlayOneShot(clipToPlay, .6f);
				
			}else{
				playAudioClipOneShot(clipToPlay);
			}
			
			//playAudioClipOneShot(clipToPlay);
			
			yield return new WaitForSeconds(clipLength);
		}
		leaveScript.gameObject.SetActive(true);
		offPhone();
		
	}

	private IEnumerator onPhone(float timeToWait){

		yield return new WaitForSeconds(timeToWait);
		ghoulMoanScript.onPhone(true);
		chaosScript.setIsSpawningGhoul(false);
		scaryAudioScript.setScared(false);
		scaryAudioScript.decreaseVolume(scaryAudioScript.getVolume()/2);
	}

	private void offPhone(){

		ghoulMoanScript.onPhone(false);
		chaosScript.setIsSpawningGhoul(true);
		scaryAudioScript.setScared(true);
		scaryAudioScript.setHeartbeatVolume(.8f);
		audio.PlayOneShot(lightFlicker);
		lightFlickScript.flickerOff();
		//scaryAudioScript.StartCoroutine("fadeLoud", .8f);
	}

	private void playAudioClipOneShot(AudioClip clip){

		audio.Stop();

		audio.loop = false;
		audio.PlayOneShot(clip);
		
	}
	
	private void playAudioClipContinous(AudioClip clip){

		audio.Stop();

		audio.loop = true;
		audio.clip = clip;
		audio.Play();
		
	}

	public void ringPhone(){

		playAudioClipContinous(ringing);

	}


}
