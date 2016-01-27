using UnityEngine;
using System.Collections;

public class AdjustScript : MonoBehaviour {

	void OnGUI(){

		GUI.Label (new Rect (125, 100, 100, 30), "Health: " + GameControl.control.playerHealth);
		GUI.Label (new Rect (125, 140, 100, 30), "Stamina: " + GameControl.control.playerStamina);
		GUI.Label (new Rect (125, 120, 100, 30), "Max Health: " + GameControl.control.playerMaxHealth);
		GUI.Label (new Rect (125, 160, 100, 30), "Max Stamina: " + GameControl.control.playerMaxStamina);
		GUI.Label (new Rect (125, 180, 100, 30), "Strength: " + GameControl.control.playerSTRLevel);
		GUI.Label (new Rect (125, 220, 100, 30), "Dexterity: " + GameControl.control.playerDEXLevel);

		if (GUI.Button (new Rect (10, 100, 100, 30), "Health up")) {
			//Utilizes the static object in the GameControl script to access its local variable
			GameControl.control.playerHealth += 10;
		}
		if (GUI.Button (new Rect (10, 120, 100, 30), "Health down")) {
			GameControl.control.playerHealth -= 10;
		}
		if (GUI.Button (new Rect (10, 140, 100, 30), "Stamina up")) {
			GameControl.control.playerStamina += 10;
		}
		if (GUI.Button (new Rect (10, 160, 100, 30), "Stamina down")) {
			GameControl.control.playerStamina -= 10;
		}
		if (GUI.Button (new Rect (10, 180, 100, 30), "STR up")) {
			GameControl.control.playerSTRLevel += 10;
		}
		if (GUI.Button (new Rect (10, 200, 100, 30), "STR down")) {
			GameControl.control.playerSTRLevel -= 10;
		}
		if (GUI.Button (new Rect (10, 220, 100, 30), "DEX up")) {
			GameControl.control.playerDEXLevel += 10;
		}
		if (GUI.Button (new Rect (10, 240, 100, 30), "DEX down")) {
			GameControl.control.playerDEXLevel -= 10;
		}
		if (GUI.Button (new Rect (10, 380, 100, 30), "Save Game")) {
			//Runs the Save method from the GameControl script
			GameControl.control.Save ();
		}
		if (GUI.Button (new Rect (10, 400, 100, 30), "Load Game")) {
			GameControl.control.Load ();
		}
	}
}
