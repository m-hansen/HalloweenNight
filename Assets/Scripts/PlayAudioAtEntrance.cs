using UnityEngine;
using System.Collections;

public class PlayAudioAtEntrance : MonoBehaviour {
	public AudioClip audio1;
	private bool hasPlayed = false;

	public GameObject interactTrigger;
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Interact" && hasPlayed == false) {
				audio.PlayOneShot (audio1, 0.4f);
				hasPlayed = true;
		}
	}
}
