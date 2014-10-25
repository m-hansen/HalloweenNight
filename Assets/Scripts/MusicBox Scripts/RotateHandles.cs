using UnityEngine;
using System.Collections;

public class RotateHandles : MonoBehaviour {

	public GameObject handle;
	public GameObject guts;

	public float handleRotationSpeed = 20f;
	public float gutsRotationmSpeed = 20f;

	private Vector3 handleRotAxis, gutsRotAxis;

	// Use this for initialization
	void Start () {
	
		handleRotAxis = new Vector3(1, 0, 0);
		gutsRotAxis = new Vector3(0, 1, 0);

	}
	
	// Update is called once per frame
	void Update () {

		handle.transform.Rotate(handleRotAxis, Time.deltaTime * handleRotationSpeed);
		guts.transform.Rotate(gutsRotAxis, Time.deltaTime * gutsRotationmSpeed);
	
	}
}
