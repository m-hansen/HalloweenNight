using UnityEngine;
using System.Collections;

public class ButlerCollision : MonoBehaviour {
	public AudioClip monsterRoar;
	private bool isBeingLookedAt = false;
	private float lookedAtTimer;
	private int counter = 0;
	public Tonemapping toneMapping1;
	public Tonemapping toneMapping2;

	private SceneFadeInOut sceneFade;


	// Use this for initialization
	void Start () {
		toneMapping1 = GameObject.Find ("CameraRight").GetComponent<Tonemapping>();
		toneMapping2 = GameObject.Find ("CameraLeft").GetComponent<Tonemapping>();
		sceneFade = GameObject.FindGameObjectWithTag ("Player").GetComponent<SceneFadeInOut> ();
	}
	
	// Update is called once per frame
	void Update () {
			if (isBeingLookedAt) {
			if(lookedAtTimer >= 0.1 && lookedAtTimer <= 0.3){
				toneMapping1.enabled = true;
				toneMapping2.enabled = true;
			}
			if(lookedAtTimer >= 0.4 && lookedAtTimer <= 0.6){
				toneMapping1.enabled = false;
				toneMapping2.enabled = false;
			}
			if(lookedAtTimer >= 0.6 && lookedAtTimer <= 0.8){
				toneMapping1.enabled = true;
				toneMapping2.enabled = true;
			}
			if(lookedAtTimer >= 0.8 && lookedAtTimer <= 1){
				toneMapping1.enabled = false;
				toneMapping2.enabled = false;
			}

		
				lookedAtTimer += Time.deltaTime;
				if(lookedAtTimer >= 1.0f){
					Debug.Log ("hsadsai");
					this.transform.parent.transform.Translate(-Vector3.forward * Time.deltaTime * 16);
				}
				if(lookedAtTimer >= 3.0f){
					sceneFade.StartCoroutine("fadeBlack");
				}
				if(lookedAtTimer >= 5.0f){
					Application.LoadLevel("ShannanHouse");
				}
			}
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "ViewDirection" && isBeingLookedAt == false) {
		
			isBeingLookedAt = true;
			audio.PlayOneShot(monsterRoar, 1.0f);
				}
		}
}
