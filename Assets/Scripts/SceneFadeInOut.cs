using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour{

	//public float fadeSpeed = 1.5f;

	private GameObject cubeToFade;
	private MeshRenderer cubeMesh;
	private Material cubeMaterial;

	void Start(){

		cubeToFade = GameObject.FindGameObjectWithTag("ViewDirection");
		cubeMesh = cubeToFade.GetComponent<MeshRenderer>();
		cubeMaterial = cubeMesh.material;
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.Return)){

			StartCoroutine("fadeBlack");

		}else if(Input.GetKeyDown(KeyCode.Period)){

			StartCoroutine("fadeClear");

		}else if(Input.GetKeyDown(KeyCode.Comma)){

			StartCoroutine("flashWhite");

		}

	}
	

	public IEnumerator fadeBlack(){
		
		cubeMaterial.color = Color.clear;
		
		while(cubeMaterial.color.a < 1){
			
			Color change = cubeMaterial.color;
			change.a += .05f;
			
			cubeMaterial.color = change;
			
			yield return null;
		}
		
		
	}


	public IEnumerator fadeClear(){
		
		cubeMaterial.color = Color.black;
		
		while(cubeMaterial.color.a > 0){
			
			Color change = cubeMaterial.color;
			change.a -= .05f;
			
			cubeMaterial.color = change;
			
			yield return null;
		}
		
		
	}

	public IEnumerator flashWhite(){

		cubeMaterial.color = Color.white;

		yield return null;

		cubeMaterial.color = Color.clear;

	}

}