using UnityEngine;
using System.Collections;

public class effectSunlight : MonoBehaviour {

	Light lt;
	float lightIntensity = worldClock.lightIntensity;

	// Use this for initialization
	void Start () {
		lt = GetComponent<Light>();
		lt.intensity = lightIntensity;
	}

	// Update is called once per frame
	void Update () 
	{
		lightIntensity = worldClock.lightIntensity;
		lt.intensity = lightIntensity;
	}
}