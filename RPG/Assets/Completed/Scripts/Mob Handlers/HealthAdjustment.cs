using UnityEngine;

using System.Collections;

using UnityEngine.UI;
public class HealthAdjustment : MonoBehaviour {

	MobHandler handlerScript;
	public Image healthImage;
	public float healthReduc = 1.0f;

	// Use this for initialization
	void Start ()
	{
		healthImage = GetComponent<Image> ();
		handlerScript = this.transform.parent.gameObject.transform.parent.gameObject.GetComponent<MobHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		//Call the total and max health from the watcherHandler script.
		//Adjust the fillAmount for the image based on
		healthReduc = handlerScript.currentHealth / handlerScript.maxHealth;
		healthImage.fillAmount = healthReduc;
	}
}
