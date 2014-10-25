using UnityEngine;
using System.Collections;

public class HouseGhoulMoans : MonoBehaviour {

	public AudioSource[] sources;
	public AudioClip[] clips;

	private AudioSource currentSource;
	private AudioClip currentClip;

	private bool isOnPhone = false;
	
	void Start () {

		StartCoroutine("ghoulSounds");
	
	}

	void Update () {
	
	}

	private IEnumerator ghoulSounds(){

		while(!isOnPhone){

			currentClip = null;
			currentSource = null;

			//UnityEngine.Debug.Log(clips.Length);
			currentClip = getGhoulNoise();
			currentSource = getGhoulSource();

			currentSource.PlayOneShot(currentClip);

			yield return new WaitForSeconds(Random.Range(0, 5));
		}

	}

	public void onPhone(bool phoneState){

		isOnPhone = phoneState;

		if(isOnPhone == false){
			StartCoroutine("ghoulSounds");
		}

	}

	public bool getPhoneStatus(){
		return isOnPhone;
	}

	private AudioSource getGhoulSource(){

		return sources[Random.Range(0, sources.Length)];
	}

	private AudioClip getGhoulNoise(){

		return clips[Random.Range(0, clips.Length)];
	}
}
