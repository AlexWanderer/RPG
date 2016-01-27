using UnityEngine;
using System.Collections;
//Used for binary serialization. XML format available.
using System;
using System.Runtime.Serialization.Formatters.Binary;
//Input/output operator
using System.IO;

public class GameControl : MonoBehaviour {



	//Creates the static object for access by any other script
	public static GameControl control;


	//						 //
	//Location and World Data//
	//						 //
	//
	//Time data
	public int worldTimeYear;
	public int worldTimeMonth;
	public int worldTimeDay;
	public int worldTimeHour;
	public int worldTimeMin;
	public string ampm;
	public float lightIntensity;

	//
	//Stats and Leveling
	//
	//Raw Level for each of the player's stats
	public float playerSTRLevel = 0.0f;
	public float playerDEXLevel = 0.0f;
	public float playerINTLevel = 0.0f;
	public float playerADPLevel = 0.0f;
	public float playerDIVLevel = 0.0f;
	public float playerCRSLevel = 0.0f;

	//Current Experience level for each of the player's stats
	public float playerSTRExp = 0.0f;
	public float playerDEXExp = 0.0f;
	public float playerINTExp = 0.0f;
	public float playerADPExp = 0.0f;
	public float playerDIVExp = 0.0f;
	public float playerCRSExp = 0.0f;

	//Health and Stamina Levels
	public float playerHealth = 50.0f;
	public float playerMaxHealth = 50.0f;
	public float playerStamina = 50.0f;
	public float playerMaxStamina = 50.0f;
	public float playerHealthRegen = 1.0f;
	public float playerStaminaRegen = 1.0f;

	//Bonuses
	public float dodgeBNS = 0.0f;
	public float meleeATKBNS = 0.0f;
	public float magicATKBNS = 0.0f;
	public float curseATKBNS = 0.0f;
	public float divineATKBNS = 0.0f;
	public float meleeDEFBNS = 0.0f;
	public float magicDEFBNS = 0.0f;
	public float curseDEFBNS = 0.0f;
	public float divineDEFBNS = 0.0f;

	void Start () {
		StatAdjustment ();
	}

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	void Update () {
		StatAdjustment ();
	}

	public void Save () {
		//Creates the binary formatter
		BinaryFormatter bf = new BinaryFormatter ();
		//Filestream operator to create the .dat file
		FileStream file = File.Create (Application.persistentDataPath + "/saveData.dat");

		//Creates a new data table based on the variables stored in the PlayerData class.
		PlayerData data = new PlayerData ();

		//replaces the variables taken from PlayerData with the current variables in the newly created data table.
		data.worldTimeYear = worldClock.worldTimeYear;
		data.worldTimeMonth = worldClock.worldTimeMonth;
		data.worldTimeDay = worldClock.worldTimeDay;
		data.worldTimeHour = worldClock.worldTimeHour;
		data.worldTimeMin = worldClock.worldTimeMin;
		data.ampm = worldClock.ampm;
		data.lightIntensity = worldClock.lightIntensity;
		data.playerSTRLevel = playerSTRLevel;
		data.playerDEXLevel = playerDEXLevel;
		data.playerINTLevel = playerINTLevel;
		data.playerADPLevel = playerADPLevel;
		data.playerDIVLevel = playerDIVLevel;
		data.playerCRSLevel = playerCRSLevel;
		data.playerSTRExp = playerSTRExp;
		data.playerDEXExp = playerDEXExp;
		data.playerINTExp = playerINTExp;
		data.playerADPExp = playerADPExp;
		data.playerDIVExp = playerDIVExp;
		data.playerCRSExp = playerCRSExp;
		data.playerHealth = playerHealth;
		data.playerMaxHealth = playerMaxHealth;
		data.playerStamina = playerStamina;
		data.playerMaxStamina = playerMaxStamina;
		data.playerHealthRegen = playerHealthRegen;
		data.playerStaminaRegen = playerStaminaRegen;
		data.dodgeBNS = dodgeBNS;
		data.meleeATKBNS = meleeATKBNS;
		data.magicATKBNS = magicATKBNS;
		data.curseATKBNS = curseATKBNS;
		data.divineATKBNS = divineATKBNS;
		data.meleeDEFBNS = meleeDEFBNS;
		data.magicDEFBNS = magicDEFBNS;
		data.curseDEFBNS = curseDEFBNS;
		data.divineDEFBNS = divineDEFBNS;

		//Use the created binary formatter to store the data table's info into the playerInfo.dat file
		bf.Serialize (file, data);
		//Close the file opened by the filestream
		file.Close();
	}

	public void Load () {

		//Checks to see if the file exists
		if (File.Exists (Application.persistentDataPath + "/saveData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			//FileMode.Open is required to open the file
			FileStream file = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);

			//Deserializes the binary data so that it's readable in the format of the PlayerData class
			PlayerData data = (PlayerData)bf.Deserialize (file);

			//Sets the local health and exp variables to the ones loaded from the file
			worldClock.worldTimeYear = data.worldTimeYear;
			worldClock.worldTimeMonth = data.worldTimeMonth;
			worldClock.worldTimeDay = data.worldTimeDay;
			worldClock.worldTimeHour = data.worldTimeHour;
			worldClock.worldTimeMin = data.worldTimeMin;
			worldClock.ampm = data.ampm;
			worldClock.lightIntensity = data.lightIntensity;
			playerSTRLevel = data.playerSTRLevel;
			playerDEXLevel = data.playerDEXLevel;
			playerINTLevel = data.playerINTLevel;
			playerADPLevel = data.playerADPLevel;
			playerDIVLevel = data.playerDIVLevel;
			playerCRSLevel = data.playerCRSLevel;
			playerSTRExp = data.playerSTRExp;
			playerDEXExp = data.playerDEXExp;
			playerINTExp = data.playerINTExp;
			playerADPExp = data.playerADPExp;
			playerDIVExp = data.playerDIVExp;
			playerCRSExp = data.playerCRSExp;
			playerHealth = data.playerHealth;
			playerMaxHealth = data.playerMaxHealth;
			playerStamina = data.playerStamina;
			playerMaxStamina = data.playerMaxStamina;
			playerHealthRegen = data.playerHealthRegen;
			playerStaminaRegen = data.playerStaminaRegen;
			dodgeBNS = data.dodgeBNS;
			meleeATKBNS = data.meleeATKBNS;
			magicATKBNS = data.magicATKBNS;
			curseATKBNS = data.curseATKBNS;
			divineATKBNS = data.divineATKBNS;
			meleeDEFBNS = data.meleeDEFBNS;
			magicDEFBNS = data.magicDEFBNS;
			curseDEFBNS = data.curseDEFBNS;
			divineDEFBNS = data.divineDEFBNS;
		}
	}

	void StatAdjustment () {
		float healthStrBonus = playerSTRLevel * 20.0f;
		float healthFormula = 50.0f + healthStrBonus;
		float staminaDexBonus = playerDEXLevel * 20.0f;
		float staminaFormula = 50.0f + staminaDexBonus;
		playerMaxHealth = healthFormula;
		playerMaxStamina = staminaFormula;
	}
}

//Tags the class beneath as serializable, making it available for binary storage formatting
[Serializable]
class PlayerData
{
	//Variables are merely defined for listing purposes. No values need to be applied.

	//						 //
	//Location and World Data//
	//						 //
	//
	//Time data
	public int worldTimeYear;
	public int worldTimeMonth;
	public int worldTimeDay;
	public int worldTimeHour;
	public int worldTimeMin;
	public string ampm;
	public float lightIntensity;

	//
	//Stats and Leveling
	//
	//Raw Level for each of the player's stats
	public float playerSTRLevel = 0.0f;
	public float playerDEXLevel = 0.0f;
	public float playerINTLevel = 0.0f;
	public float playerADPLevel = 0.0f;
	public float playerDIVLevel = 0.0f;
	public float playerCRSLevel = 0.0f;

	//Current Experience level for each of the player's stats
	public float playerSTRExp = 0.0f;
	public float playerDEXExp = 0.0f;
	public float playerINTExp = 0.0f;
	public float playerADPExp = 0.0f;
	public float playerDIVExp = 0.0f;
	public float playerCRSExp = 0.0f;

	//Health and Stamina Levels
	public float playerHealth = 50.0f;
	public float playerMaxHealth = 50.0f;
	public float playerStamina = 50.0f;
	public float playerMaxStamina = 50.0f;
	public float playerHealthRegen = 1.0f;
	public float playerStaminaRegen = 1.0f;

	//Bonuses
	public float dodgeBNS = 0.0f;
	public float meleeATKBNS = 0.0f;
	public float magicATKBNS = 0.0f;
	public float curseATKBNS = 0.0f;
	public float divineATKBNS = 0.0f;
	public float meleeDEFBNS = 0.0f;
	public float magicDEFBNS = 0.0f;
	public float curseDEFBNS = 0.0f;
	public float divineDEFBNS = 0.0f;
}
