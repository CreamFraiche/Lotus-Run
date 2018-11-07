using UnityEngine;
using System.Collections;

public class swordPick : MonoBehaviour {

	public string wepString;
	
	// Use this for initialization
	void Start () {
		wepString = PlayerPrefs.GetString("Weapon1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void parseString(){
		
	
	}
}
