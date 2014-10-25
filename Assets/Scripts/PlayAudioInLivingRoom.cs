using UnityEngine;
using System.Collections;

public class PlayAudioInLivingRoom : MonoBehaviour {
	private float timer = 0;
	private bool hasCollided = false;
	public GameObject frontDoor;
	public GameObject musicBox;
	public AudioClip thisIsWeird;
	public AudioClip oldManScream;
	public AudioClip gotToGetOutOfHere;
	public AudioClip doorSlam;
	public AudioClip needALight;
	public GameObject bloodParticles;
	public GameObject flashLightTable;
	

	private bool onTheWayOut = false;
	private DoorOpenClose frontDoorControl;


	private int hitThisCounter = 0;
	private int speakCounter = 0;
	// Use this for initialization
	void Start () {
		frontDoorControl = frontDoor.GetComponent<DoorOpenClose>();

	}
	
	// Update is called once per frame
	void Update () {
		if (hasCollided) {
			timer += Time.deltaTime;
			if(timer >= 10.0f && speakCounter == 0){
				musicBox.audio.enabled = true;
				Debug.Log ("hi12321");
				speakCounter++;
			}
			if(timer >= 15.0f && speakCounter == 1){
				audio.PlayOneShot(thisIsWeird, 0.6f);
				speakCounter++;
			}
			if(timer >= 25.0f & speakCounter == 2){
				audio.PlayOneShot(oldManScream, 0.7f);
				frontDoorControl.rotateDoor = true;
				LightFlicker.isFlickering = true;
				LightFlicker.beginFlickering = true;
				speakCounter++;
			}
			//disable the lights
			if(timer >= 27.0f && speakCounter == 3){
				bloodParticles.particleSystem.Play();
				musicBox.audio.mute = true;
				speakCounter++;
				LightFlicker.disableLights = true;
				LightFlicker.isFlickering = false;
			}
			if(timer >= 29f && speakCounter == 4){
				bloodParticles.particleSystem.Stop();
				audio.PlayOneShot(gotToGetOutOfHere, 0.7f);
				speakCounter++;
			}
			if(timer >= 36.0f && speakCounter == 5){
				audio.PlayOneShot(needALight, 0.7f);
				flashLightTable.SetActive(true);
				speakCounter++;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (hasCollided == false && other.gameObject.tag == "Interact") {
			hasCollided = true;
		}
		if (other.gameObject.tag == "Interact" && speakCounter >= 2 && onTheWayOut == false){
			onTheWayOut = true;
			frontDoorControl.rotateDoor = true; 
			audio.PlayOneShot(doorSlam, 0.7f);;
		}
	}
}
