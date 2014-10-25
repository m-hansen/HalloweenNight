using UnityEngine;
using System.Collections;

public class LeaveInteraction : MonoBehaviour {

	private SceneFadeInOut fadeScript;

	// Use this for initialization
	void Start () {

		fadeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneFadeInOut>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	private IEnumerator loadScene(){

		yield return new WaitForSeconds(2f);

		Application.LoadLevel("Official Ending Scene");

	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "Interact"){
			fadeScript.StartCoroutine("fadeBlack");
			StartCoroutine("loadScene");
		}

	}
}
