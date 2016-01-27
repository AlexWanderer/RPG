using UnityEngine;
using System.Collections;

public class DebugOutput : MonoBehaviour {
	static string myLog = "";
	private string output;
	private string stack;

	void OnEnable()
	{
		Application.logMessageReceived += Log;
	}

	void OnDisable()
	{
		Application.logMessageReceived -= Log;
	}

	public void Log(string logString, string stackTrace, LogType type)
	{
		output = logString;
		stack = stackTrace;
		myLog = output + "\n" + myLog;
		if (myLog.Length > 5000)
		{
			myLog = myLog.Substring(0, 4000);
		}
	}

	void OnGUI()
	{
		myLog = GUI.TextArea(new Rect(500, 10, Screen.width - 400, Screen.height - 100), myLog);
	}
}