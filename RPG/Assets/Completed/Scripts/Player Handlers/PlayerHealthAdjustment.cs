using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthAdjustment : MonoBehaviour {

	public Image healthImage;
	public float healthReduc = 1.0f;

	void Start ()
	{
		healthImage = GetComponent<Image> ();
	}

	void Update () {
		//Call the total and max health from the watcherHandler script.
		//Adjust the fillAmount for the image based on
		healthReduc = GameControl.control.playerHealth / GameControl.control.playerMaxHealth;
		healthImage.fillAmount = healthReduc;
	}
}
