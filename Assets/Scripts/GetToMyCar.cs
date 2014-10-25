using UnityEngine;
using System.Collections;

public class GetToMyCar : MonoBehaviour {

	private bool hasBeenPlayed = false;
	public AudioClip getToMyCar;

	

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Interact") {
			if (hasBeenPlayed == false) {
				audio.PlayOneShot(getToMyCar, 1);
				hasBeenPlayed = true;
			}
		}
	}
}
