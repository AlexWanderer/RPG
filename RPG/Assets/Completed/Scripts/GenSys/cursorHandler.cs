using UnityEngine;
using System.Collections;

public class cursorHandler : MonoBehaviour {

	Animator anim;
	int i = 1;
	bool toggleOn = true;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		if (Input.GetButtonDown ("Submit")) 
		{
			OpenMenuFunction ();
		}

		if (toggleOn)
		{
			if (Input.GetAxis ("Vertical") > 0)
			{
				MoveCursorUp ();
				toggleOn = false;
			}
			if (Input.GetAxis ("Vertical") < 0)
			{
				MoveCursorDown ();
				toggleOn = false;
			}
		}
		
		if (Input.GetAxis ("Vertical") == 0)
		{
			toggleOn = true;
		}

	}

	void MoveCursorUp()
	{
		Debug.Log("Up");
		if (i == 1) {
			i++;
			i++;
			anim.Play ("MainMenuCursor3");
		} else if (i == 2) {
			i--;
			anim.Play ("MainMenuCursor");
		} else if (i == 3) {
			i--;
			anim.Play ("MainMenuCursor2");
		}
	}

	void MoveCursorDown()
	{
		Debug.Log("Down");
		if (i == 1) {
			i++;
			anim.Play ("MainMenuCursor2");
		} else if (i == 2) {
			i++;
			anim.Play ("MainMenuCursor3");
		} else if (i == 3) {
			i--;
			i--;
			anim.Play ("MainMenuCursor");
		}
	}

	void OpenMenuFunction()
	{
		if (i == 1) {
			Application.LoadLevel("Level");
		}
		else if (i == 2) 
		{
			Application.LoadLevel("Level");
		}
		else if (i == 3)
		{
			Debug.Log("Options");
		}
	}
}