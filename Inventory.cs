using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
		
	private Texture currentWeaponTexture;	//Current weapon GUI picture
	public Texture weapon1, weapon2, weapon3, weapon4;	//Weapon GUI pictures
	public GameObject inventory;
	public string stats1;
	public string stats2;
	public string stats3;
	public string stats4;
	public int curWep;
	public int j;

	void Start () {
		inventory = GameObject.FindGameObjectWithTag("inventory");
		curWep = inventory.GetComponent<newInven>().getEquiped();
		stats1 = inventory.GetComponent<newInven>().getItemStats(curWep);
	}
	
	void Update () {
		//check to see what the current weapon is
		if (stats1[0] == 1) {
			currentWeaponTexture = weapon1;
		}
		
		else if (stats1[0] == 2) {
			currentWeaponTexture = weapon2;
		}
		
		else if (stats1[0] == 3)  {
			currentWeaponTexture = weapon3;
		}
		
		else if (stats1[0] == 4)  {
			currentWeaponTexture = weapon4;
		}
	}

	void OnGUI () {
		//group for the inventory
		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		//background box
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

		//box for the current weapon
		GUI.DrawTexture(new Rect(Screen.width/12, Screen.height/4, Screen.width/2, Screen.height/3), currentWeaponTexture, ScaleMode.StretchToFill);

		//box that says current weapon, using placholder font
		GUI.Box(new Rect(Screen.width/12, Screen.height/10, Screen.width/2, Screen.height/10), "Current Weapon");

		//box that says current weapon stats, using placholder font
		GUI.Box(new Rect(Screen.width/12, (Screen.height/12) * 8, Screen.width/2, Screen.height/5), inventory.GetComponent<newInven>().getItemStats(curWep));

		//button to go to the next level

		if (GUI.Button(new Rect(((Screen.width/3) * 2),(Screen.height/36) * 29, Screen.width/6, Screen.height/6), "Next Level" )) {

			Application.LoadLevel("level" + PlayerPrefs.GetInt("CurrentLevel"));
		}

		GUI.EndGroup();
	}
}