using UnityEngine;
using System.Collections;

public class FlashLightInteraction : InteractableObject {

	private GameObject playerFlashLight;
	private DoorOpenClose stairsDoorControl;
	private DoorOpenClose stairsDoorControl2;
	public GameObject stairsDoor;
	public GameObject stairsDoor2;
	public GameObject violin;

	// Use this for initialization
	void Start () {
		playerFlashLight = GameObject.Find ("PlayerFlashLight");
		stairsDoorControl = stairsDoor.GetComponent<DoorOpenClose>();
		stairsDoorControl2 = stairsDoor2.GetComponent<DoorOpenClose>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void Activate(){
		GameObject.FindGameObjectWithTag ("Interact").GetComponent<PlayerInteraction> ().disableMeshOverride ();
		enableFlashLight ();

		stairsDoorControl.rotateDoor = true;
		stairsDoorControl2.rotateDoor = true;
		
	}
	public void enableFlashLight(){
		Debug.Log ("goof");
		violin.audio.enabled = true;
		playerFlashLight.light.enabled = true;
	}

}
