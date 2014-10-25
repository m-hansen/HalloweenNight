using UnityEngine;
using System.Collections;

public class DoorOpenClose : MonoBehaviour {

	public enum DoorStateEnum {
		Closed,
		Open,
		TransitionFromClosed,
		TransitionFromOpen
	};

	private float deltaT = 0.0f;
	public bool rotateReverse = false;
	private float speed = 3.0f;
	private float currentAngle = 0.0f;
	private float minHingeAngle = 0.0f;
	private float maxHingeAngle = 100.0f;
	public bool rotateDoor = false;

	private bool isLocked = false;

	public DoorStateEnum state;

	// Use this for initialization
	void Start () {
		state = DoorStateEnum.Closed;
	}
	
	// Update is called once per frame
	void Update () {

		// Update the state
		if (currentAngle >= maxHingeAngle) {
			state = DoorStateEnum.Open;
			//direction = 1.0f;
		}
		else if (currentAngle <= minHingeAngle) {
			state = DoorStateEnum.Closed;
			//direction = -1.0f;
		}

		// Check for interaction and update state
		if (rotateDoor && !isLocked) {

			if (state == DoorStateEnum.Closed) {
				state = DoorStateEnum.TransitionFromClosed;
				deltaT = 0.0f;
			}
			else if (state == DoorStateEnum.Open) {
				state = DoorStateEnum.TransitionFromOpen;
				deltaT = 0.0f;
			}
			rotateDoor = false;

		}

		// Update the time delta based on speed
		if (deltaT < 1) {
			deltaT += Time.deltaTime * speed;
		}

		// Rotate the door on an interval
		if (state == DoorStateEnum.TransitionFromClosed && !rotateReverse) {
			currentAngle = Mathf.LerpAngle(minHingeAngle, maxHingeAngle, deltaT);
		}
		else if (state == DoorStateEnum.TransitionFromOpen  && !rotateReverse) {
			currentAngle = Mathf.LerpAngle(maxHingeAngle, minHingeAngle, deltaT);
		}
		// Rotate the door on an interval
		else if (state == DoorStateEnum.TransitionFromClosed && rotateReverse) {
			Debug.Log ("GOOGOOGAAGAA");
			currentAngle = Mathf.LerpAngle(maxHingeAngle, maxHingeAngle, deltaT);
		}
		else if (state == DoorStateEnum.TransitionFromOpen  && rotateReverse) {
			currentAngle = Mathf.LerpAngle(minHingeAngle, minHingeAngle, deltaT);
		}

		transform.eulerAngles = new Vector3 (0, currentAngle, 0);

	}

}
