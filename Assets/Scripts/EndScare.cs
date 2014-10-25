using UnityEngine;
using System.Collections;

public class EndScare : MonoBehaviour {

	private bool hasBeenPlayed = false;
	public GameObject endMonster;
	public GameObject endMonster2;
	public static bool finalScare;
	
	
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Interact") {
			if (hasBeenPlayed == false && EndGame.endScare == true) {
				endMonster.renderer.enabled = true;
				endMonster2.renderer.enabled = true;
				hasBeenPlayed = true;
				finalScare = true;
			}
		}
	}
}
