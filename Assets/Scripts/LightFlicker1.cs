using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class LightFlicker1 : MonoBehaviour {

	private bool isLightOn = true;
	public static bool isFlickering = false;
	public static bool disableLights = false;
	public static bool beginFlickering = false;
	private Transform lightChild;
	private Transform meshChild;
	private Stopwatch stopwatch;
	public static long timeFlickeringBegins;
	private const long FLICKER_DURATION = 10000; // in ms
	private const float FLICKER_PROBABILITY = 0.1f;

	// Initialize
	void Start() {
		stopwatch = new Stopwatch();
		timeFlickeringBegins = 0;
		stopwatch.Start ();
		meshChild = transform.Find ("LightPart");
		lightChild = transform.Find ("Spotlight");
	}

	// Update is called once per frame
	void Update () {
	
		if (beginFlickering) {
			timeFlickeringBegins = stopwatch.ElapsedMilliseconds;
			beginFlickering = false;
				}

		if (isFlickering) {

			// Flicker for duration
			if ((stopwatch.ElapsedMilliseconds - timeFlickeringBegins) < FLICKER_DURATION) {
				// Only flicker based on probability
				if (Random.value < FLICKER_PROBABILITY) {
					isLightOn = !isLightOn;
					foreach(Material matt in meshChild.renderer.materials)
					{
						if(matt.shader.name == "Decal"){
							matt.shader =  Shader.Find("Self-Illumin/Diffuse");
						}
						else if(matt.shader.name == "Self-Illumin/Diffuse"){
							matt.shader =  Shader.Find("Decal");
						}
				//	meshChild.renderer.material.shader =  Shader.Find("Diffuse");
					}
				}
			}
			// duration exceeded
			else {
				isFlickering = false;
				isLightOn = true; // state of the light after flickering
			}

		}
		if(!disableLights){
			lightChild.light.enabled = isLightOn;

		}
		if(disableLights){
			lightChild.light.enabled = false;

			foreach(Material matt in meshChild.renderer.materials)
			{
				 if(matt.shader.name == "Self-Illumin/Diffuse"){
					matt.shader =  Shader.Find("Decal");
				}
			}
		}
	}
}
