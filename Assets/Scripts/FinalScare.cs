using UnityEngine;
using System.Collections;

public class FinalScare : MonoBehaviour {

	
	private bool hasBeenPlayed = false;
	public AudioClip finalScare;
	public GameObject monster;
	private float timer;
	private SceneFadeInOut fadeScript;
	public AudioClip scareNoise;

	public Tonemapping toneMapping1;
	public Tonemapping toneMapping2;



	
	void Start(){
		fadeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneFadeInOut>();

		toneMapping1 = GameObject.Find ("CameraRight").GetComponent<Tonemapping>();
		toneMapping2 = GameObject.Find ("CameraLeft").GetComponent<Tonemapping>();
		}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Interact" && EndScare.finalScare == true) {
				if (hasBeenPlayed == false) {
						audio.PlayOneShot (finalScare, 1);
						audio.PlayOneShot(scareNoise, 1);
						hasBeenPlayed = true;
				}

		}
	}

	void Update(){
		if(hasBeenPlayed){
			timer+= Time.deltaTime;
			monster.transform.Translate(-Vector3.forward * (Time.deltaTime * 18));
		}
		if(timer >= 1){
			fadeScript.StartCoroutine("fadeBlack");
		}
		if(timer >=5){
			Application.LoadLevel("Credits");
		}

		if(timer >= 0.1 && timer <= 0.3){
			toneMapping1.enabled = true;
			toneMapping2.enabled = true;
		}
		if(timer >= 0.4 && timer <= 0.6){
			toneMapping1.enabled = false;
			toneMapping2.enabled = false;
		}
		if(timer >= 0.6 && timer <= 0.8){
			toneMapping1.enabled = true;
			toneMapping2.enabled = true;
		}
		if(timer >= 0.8 && timer <= 1){
			toneMapping1.enabled = false;
			toneMapping2.enabled = false;
		}

	}
}
