using UnityEngine;
using System.Collections;

public class worldClock : MonoBehaviour {

	public float lastChange = 0.0f;
	
	public static int worldTimeYear = 1;
	public static int worldTimeMonth = 01;
	public static int worldTimeDay = 01;
	public static int worldTimeHour = 09;
	public static int worldTimeMin = 00;
	public static string ampm = "pm";
	public static string clockDisplay = "Loading..";
	public static float lightIntensity = 0.0f;

	// Update is called once per frame
	void Update()
	{
		//Initiates every 2.5 seconds to increase the world clock's minutes.
		if (Time.time - lastChange > 2.5)
		{
			worldTimeMin++;
			if (worldTimeMin == 60)
			{
				worldTimeMin = 0;
				worldTimeHour++;
				if (worldTimeHour == 12)
				{
					if (ampm == "am")
					{
						ampm = "pm";
					} else {
						ampm = "am";
						NewDay();
					}
				}
				if (worldTimeHour == 13)
				{
					worldTimeHour = 1;
				}
			}
			lastChange = Time.time;
			if (worldTimeHour >= 6 && worldTimeHour < 9)
			{
				if (ampm == "am")
				{
					SunriseFunction();
				} else {
					SunsetFunction();
				}
			} else if (worldTimeHour == 9)
			{
				if (ampm == "am")
				{
					lightIntensity = 2.5f;
				} else {
					lightIntensity = 0.0f;
				}
			}
			UpdateGUIClock();
		}
	}

	//Initiates every hour to increase the calendar date.
	void NewDay()
	{
		Debug.Log ("New Day");
		worldTimeDay++;
		if (worldTimeDay == 31)
		{
			worldTimeDay = 1;
			worldTimeMonth++;
			if (worldTimeMonth == 13)
			{
				worldTimeMonth = 1;
				worldTimeYear++;
			}
		}
	}

	void UpdateGUIClock()
	{
		string clockHour = worldTimeHour.ToString("D2");
		string clockMin = worldTimeMin.ToString("D2");
		string clockText = "Day " + worldTimeDay + "@" + clockHour + ":" + clockMin + ampm;
		clockText = clockText.Replace("@", System.Environment.NewLine);
		clockDisplay = clockText;
	}

	void SunriseFunction()
	{
		Debug.Log ("Sunrise is taking place");
		float newIntensity = lightIntensity + 0.015f;
		Debug.Log ("New intensity is " + newIntensity);
		lightIntensity = newIntensity;
	}
	void SunsetFunction()
	{
		Debug.Log ("Sunset is taking place");
		float newIntensity = lightIntensity - 0.015f;
		if (newIntensity >= 0.0f) {
			lightIntensity = newIntensity;
		} else {
			lightIntensity = 0.0f;
		}
	}
}