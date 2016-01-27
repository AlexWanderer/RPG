using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeCheck : MonoBehaviour {
	
	//Storage Lists
	public static List<GameObject> enemiesInRange = new List<GameObject>();

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			if (!enemiesInRange.Contains (col.gameObject)) {
				enemiesInRange.Add (col.gameObject);
				Debug.Log (col.gameObject + " entered range");
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			if (enemiesInRange.Contains (col.gameObject)) {
				enemiesInRange.Remove (col.gameObject);
				Debug.Log (col.gameObject + " exited range");
			}
		}
	}
}
