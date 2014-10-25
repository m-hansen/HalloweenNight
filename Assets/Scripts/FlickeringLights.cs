using UnityEngine;
using System.Collections;

public class FlickeringLights : MonoBehaviour {

	public GameObject objectToFlicker;
	public float flickerSpeed = .1f;
	public float flickerLength = 1f;
	private float defaulFlickerLength = 1f;

	private float flickerStart = 0f;
	//private float flickerEnd = 0f;
	private float flickerCoroutinePause = 0f;

	// Use this for initialization
	void Start () {

		defaulFlickerLength = flickerLength;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.I)){
			flickerOn();
		}else if(Input.GetKeyDown(KeyCode.O)){
			flickerOff();
		}

	}

	public void flickerOn(){
		flickerStart = 0f;
		StartCoroutine("flickOn", objectToFlicker);
	}

	public void flickerOn(float flickPause){
		flickerStart = 0f;
		flickerCoroutinePause = flickPause;
		StartCoroutine("flickOn", objectToFlicker);
	}

	public void flickerOff(){
		flickerStart = 0f;
		StartCoroutine("flickOff", objectToFlicker);
	}

	public void flickerOff(float flickPause){
		flickerStart = 0f;
		flickerCoroutinePause = flickPause;
		StartCoroutine("flickOff", objectToFlicker);
	}

	public void flicker(){
		flickerStart = 0f;
		StartCoroutine("flickReturn", objectToFlicker);
	}
	

	public void flickerOnOff(float flickerDuration){
		flickerStart = 0f;
		flickerLength = flickerDuration;
		StartCoroutine("flickerOff");
	}

	public bool getObjectToFlickerStatus(){
		return objectToFlicker.activeSelf;
	}

	private IEnumerator flickOn(GameObject go){

		yield return new WaitForSeconds(flickerCoroutinePause);

		while(flickerStart < flickerLength){

			flickerStart += Time.deltaTime;
			go.SetActive(!go.activeSelf);
			yield return new WaitForSeconds(flickerSpeed);
		}

		flickerLength = defaulFlickerLength;
		flickerCoroutinePause = 0f;
		go.SetActive(true);
	}

	private IEnumerator flickOff(GameObject go){

		yield return new WaitForSeconds(flickerCoroutinePause);
		
		while(flickerStart < flickerLength){

			flickerStart += Time.deltaTime;
			go.SetActive(!go.activeSelf);
			yield return new WaitForSeconds(flickerSpeed);
		}

		flickerLength = defaulFlickerLength;
		flickerCoroutinePause = 0f;
		go.SetActive(false);
		UnityEngine.Debug.Log ("Lights off");
		
	}

	private IEnumerator flickReturn(GameObject go){

		bool currentState = go.activeInHierarchy;

		while(flickerStart < flickerLength){
			
			flickerStart += Time.deltaTime;
			go.SetActive(!go.activeInHierarchy);
			yield return new WaitForSeconds(flickerSpeed);
		}
		
		flickerLength = defaulFlickerLength;
		flickerCoroutinePause = 0f;
		go.SetActive(currentState);
	}

}
