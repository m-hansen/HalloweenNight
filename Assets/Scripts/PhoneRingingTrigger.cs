using UnityEngine;
using System.Collections;

public class PhoneRingingTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){

		GetComponentInParent<PhoneInteraction>().ringPhone();
		Destroy(this);

	}
}
