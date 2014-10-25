using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class GuiScript : MonoBehaviour {

	public AudioClip audio1;
	public AudioClip audio2;
	public AudioClip audio3;
	public GameObject interactTrigger;

	private int dialogIndex = 0;

	private bool isGuiVisible = false;
	private bool hasInteracted = false;
	private bool isDialogReady = false;
	
	private Stopwatch stopwatch = new Stopwatch();

	private void Start(){
			
		}

	public void Update() {

		// Begin dialog
		if (hasInteracted) {

			if (dialogIndex == 0 && stopwatch.ElapsedMilliseconds > 2000 ) {
				UnityEngine.Debug.Log ("Dialog1 begin");
				audio.PlayOneShot (audio1, 1.0f);
				dialogIndex++;
			}

			if (dialogIndex == 1 && stopwatch.ElapsedMilliseconds > 4000) {
				UnityEngine.Debug.Log ("Dialog2 begin");
				audio.PlayOneShot (audio2, 1.0f);
				dialogIndex++;
			}
			if(dialogIndex==2 &&stopwatch.ElapsedMilliseconds > 6000){
				UnityEngine.Debug.Log ("Dialog2 begin");
				audio.PlayOneShot (audio3, 1.0f);
				dialogIndex++;
			}
			if(dialogIndex==3 &&stopwatch.ElapsedMilliseconds > 8000){
				Application.LoadLevel("House1");
			}
		}

		if (isGuiVisible && !hasInteracted) {
			interactTrigger.renderer.enabled = true;
			if (Input.GetKeyDown (KeyCode.E)) {
				interactTrigger.renderer.enabled = false;
				UnityEngine.Debug.Log ("Key pressed");
				hasInteracted = true;
				isGuiVisible = false;
				stopwatch.Start ();
			}
		}
		if (!isGuiVisible) {
			interactTrigger.renderer.enabled = false;
				}

	}

	public void OnTriggerEnter(Collider collider)
	{
		UnityEngine.Debug.Log ("Entering OnTrigger");
		if (!hasInteracted && collider.gameObject.tag == "Interact")
			isGuiVisible = true;
	}

	public void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Interact") {
			UnityEngine.Debug.Log ("Leaving OnTrigger");
			isGuiVisible = false;
		}
	}

}
