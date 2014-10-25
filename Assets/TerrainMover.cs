using UnityEngine;
using System.Collections;

public class TerrainMover : MonoBehaviour {
	public GameObject seamlessTerrain1;
	public GameObject seamlessTerrain2;
	public float moveSpeed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		seamlessTerrain1.transform.Translate (Vector3.forward * (Time.deltaTime * moveSpeed));
		seamlessTerrain2.transform.Translate (Vector3.forward * (Time.deltaTime* moveSpeed));

		if (seamlessTerrain1.transform.position.z >= 2000)
			seamlessTerrain1.transform.position = new Vector3 (0, 0, -1998);
		if (seamlessTerrain2.transform.position.z >= 2000)
					seamlessTerrain2.transform.position = new Vector3 (0, 0, -1998); 
	}
}
