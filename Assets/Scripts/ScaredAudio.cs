using UnityEngine;
using System.Collections;

public class ScaredAudio : MonoBehaviour {

	public bool isScared;
	public float volumeChange = .05f;
	private bool activateScaryMusic;
	private float heartBeatTimer;

	public AudioClip heartBeat;
	public AudioSource scaredMusic;

	public float heartbeatVolume = .8f;
	private float targetVolumeDecrease  = 0f;
	private float targetVolumeIncrease = 1f;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		heartBeatTimer += Time.deltaTime;

		if (isScared) {

			scaredMusic.mute = false;


			if (heartBeatTimer >= 0.8f) {
				audio.PlayOneShot (heartBeat, heartbeatVolume);
				heartBeatTimer = 0;
			}
		}

		if (isScared == false) {

			scaredMusic.mute = false;
			
			
			if (heartBeatTimer >= 0.8f) {
				audio.PlayOneShot (heartBeat, heartbeatVolume);
				heartBeatTimer = 0;
			}

		}
	}

	public void increaseVolume(float targetVolume){

		targetVolumeIncrease = targetVolume;
		StartCoroutine("increaseHeartbeat");

	}

	public void decreaseVolume(float targetVolume){

		targetVolumeDecrease = targetVolume;
		StartCoroutine("decreaseHeartbeat");
		
	}

	public void setScared(bool s){
		isScared = s;
	}

	public float getVolume(){
		return heartbeatVolume;
	}

	public void setHeartbeatVolume(float vol){

		heartbeatVolume = vol;

	}

	private IEnumerator increaseHeartbeat(){

		while(heartbeatVolume < targetVolumeIncrease){

			heartbeatVolume = Mathf.Lerp(heartbeatVolume, targetVolumeIncrease, volumeChange);

			yield return null;
		}


	}

	private IEnumerator decreaseHeartbeat(){
		
		while(heartbeatVolume > targetVolumeIncrease){
			
			heartbeatVolume = Mathf.Lerp(heartbeatVolume, targetVolumeDecrease, volumeChange);
			
			yield return null;
		}
	}
}
