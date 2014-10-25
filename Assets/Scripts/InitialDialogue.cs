using UnityEngine;
using System.Collections;

public class InitialDialogue : MonoBehaviour {

	private bool hasBeenPlayed = false;
	public AudioClip initialDiaolugeAudioClip;

	

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "ViewDirection") {
			if (hasBeenPlayed == false) {
				audio.PlayOneShot(initialDiaolugeAudioClip, 1);
				hasBeenPlayed = true;
				Debug.Log ("HelloZZ");
			}
		}
	}
}
