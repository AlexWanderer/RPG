using UnityEngine.UI;
using System.Collections;

public class GUIClock : UnityEngine.MonoBehaviour {

	private Text txtRef;
	private void Awake()
	{
		txtRef = GetComponent<Text>();
	}
	
	void Update () {
		txtRef.text = worldClock.clockDisplay.ToString();
	}
}
