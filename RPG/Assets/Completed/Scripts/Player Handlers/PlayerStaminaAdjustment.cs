using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStaminaAdjustment : MonoBehaviour {

	public Image staminaImage;
	public float staminaReduc = 1.0f;

	void Start ()
	{
		staminaImage = GetComponent<Image> ();
	}

	void Update () {
		//Call the total and max health from the watcherHandler script.
		//Adjust the fillAmount for the image based on
		staminaReduc = GameControl.control.playerStamina / GameControl.control.playerMaxStamina;
		staminaImage.fillAmount = staminaReduc;
	}
}
