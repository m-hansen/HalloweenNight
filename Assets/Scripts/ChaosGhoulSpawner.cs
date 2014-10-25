using UnityEngine;
using System.Collections;

public class ChaosGhoulSpawner : MonoBehaviour {

	public FlickeringLights flickerScript;
	public float randomFlickerPause = 10f;
	public float randomGhoulPause = 10f;
	public float disableGhoulTimer = 1f;
	public float spawnCloserPercent = .5f;
	public GameObject playerLoc;
	public GameObject interactCubeLoc;

	public AudioClip scaryHit;

	private bool isRandomlyFlickering = false;
	private bool isSpawningGhoul = false;

	public MeshRenderer ghoulMesh1;
	public MeshRenderer ghoulMesh2;

	private RaycastHit hitInfo;
	private Vector3 line;



	// Use this for initialization
	void Start () {

		ghoulMesh1.enabled = false;
		ghoulMesh2.enabled = false;

		//ghoulMesh1 = GetComponent<MeshRenderer>();
		//ghoulMesh.enabled = false;

		setIsSpawningGhoul (true);
		isSpawningGhoul = true;

	}
	
	// Update is called once per frame
	void Update () {

		line = new Vector3(interactCubeLoc.transform.position.x, playerLoc.transform.position.y, interactCubeLoc.transform.position.z) - playerLoc.transform.position;
		Debug.DrawRay(playerLoc.transform.position, 10*line , Color.cyan);


		/*
		//Testing purposes
		if(Input.GetKeyDown(KeyCode.L)){
			UnityEngine.Debug.Log("starting spawn ghoul");
			setIsSpawningGhoul(true);
			isSpawningGhoul = true;
		}else if(Input.GetKeyDown(KeyCode.K)){
			isSpawningGhoul = false;
		}
		*/

	
	}

	private void spawnGhoul(){
		StartCoroutine("ghoulSpawn");
	}

	private void spawnGhoulFacingObject(GameObject obj, RaycastHit info){

		if(isSpawningGhoul){

			if(info.distance > 300f){

				float spawnDist = info.distance * spawnCloserPercent;

				Vector3 spawnPoint = info.point + spawnDist*(-1*line.normalized);

				transform.position = spawnPoint;
				ghoulMesh1.enabled = true;
				ghoulMesh2.enabled = true;
				//ghoulMesh.enabled = true;
				transform.LookAt(playerLoc.transform);

				transform.Rotate(new Vector3(0, 180, 0));
				playerLoc.audio.PlayOneShot(scaryHit);

				StartCoroutine("ghoulDespawn");

			}
		}


	}

	public void setIsSpawningGhoul(bool g){

		isSpawningGhoul = g;

		UnityEngine.Debug.Log ("we are spawning the ghoul: " + isSpawningGhoul);

		if(isSpawningGhoul == true){
			spawnGhoul();
		}
	}

	public bool getIsSpawningGhoul(){
		return isSpawningGhoul;
	}

	private IEnumerator ghoulSpawn(){

		while(isSpawningGhoul){

			if(Random.Range(0, 10) < 5){


				if(Physics.Raycast(playerLoc.transform.position, line*10, out hitInfo)){

					//UnityEngine.Debug.Log("CAN SPAWN GHOUL");
					spawnGhoulFacingObject(playerLoc, hitInfo);

				}

			}

			yield return new WaitForSeconds(randomGhoulPause);
		}
	}

	private IEnumerator ghoulDespawn(){

		yield return new WaitForSeconds(disableGhoulTimer);
		ghoulMesh1.enabled = false;
		ghoulMesh2.enabled = false;
		//ghoulMesh.enabled = false;

	}

	private IEnumerator randomFlick(){

		while(isRandomlyFlickering){

			if(Random.Range(0, 10) < 5){
				flickerScript.flicker();
			}

			yield return new WaitForSeconds(randomFlickerPause);
		}

	}


}
