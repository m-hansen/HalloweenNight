using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public MeshRenderer EtoInteractMesh;

	private InteractableObject currentInteractableScript;
	private bool interactOverride = false;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

		//An override used to disable the "E to Interact" Mesh
		if(interactOverride == true){
			EtoInteractMesh.enabled = false;
			this.enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.E)){

			if(currentInteractableScript != null){
				currentInteractableScript.Activate();
			}

		}
	
	}

	//Used to force the mesh to be diabled and then end this script
	public void disableMeshOverride(){

		interactOverride = true;

	}

	void OnTriggerEnter(Collider col){

		if(col.tag == "Interactable" ){
			if(interactOverride == false){
			EtoInteractMesh.enabled = true;
			currentInteractableScript = col.gameObject.GetComponent<InteractableObject>();
			}
		}

	}

	void OnTriggerExit(Collider col){

		if(col.tag == "Interactable"){
			
			EtoInteractMesh.enabled = false;
			currentInteractableScript = null;
			
		}

	}

}
