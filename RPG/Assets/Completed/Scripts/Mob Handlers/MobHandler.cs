using UnityEngine;
using System.Collections;

public class MobHandler : MonoBehaviour {

	//Mob Stats
	public float currentHealth = 60.0f;
	public float maxHealth = 60.0f;
	
	//int statSTR = 1;
	//int statDEX = 1;
	//int statCRS = 3;
	//int statDIV = 1;
	//int statINT = 5;
	//int statAPT = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject != null) {
			if (currentHealth == 0) {
				RangeCheck.enemiesInRange.Remove (gameObject);
				Destroy (gameObject);
			}
		}
	}
}