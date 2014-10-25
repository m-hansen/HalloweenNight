using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	private float gameTimer = 0;
	private int counter;
	public AudioClip speakingOne;
	public AudioClip musicBox;
	public AudioClip lightFlickering;
	public GameObject interactCube;
	public static bool endScare;
	// Use this for initialization
	void Start () {
		CarInteraction1.isDriving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (CarInteraction1.isDriving == true) {
			gameTimer += Time.deltaTime;
			if(gameTimer >= 2 && counter == 0){
				audio.PlayOneShot(speakingOne, 0.8f);
				counter++;
			}
			else if(gameTimer >= 12.5f && counter == 1){
				audio.PlayOneShot(musicBox, 0.8f);
				counter++;
			}
			else if(gameTimer >= 21 && counter == 2){
				audio.PlayOneShot(lightFlickering, 1f);
				LightFlicker1.beginFlickering = true;
				LightFlicker1.isFlickering = true;
				counter++;
			}
			else if(gameTimer >=26.5f && counter ==3){
				LightFlicker1.disableLights = true;
				counter++;
				endScare = true;
			}
		}
	}	
}
