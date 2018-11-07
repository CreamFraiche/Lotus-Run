using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	private int[] boosts = new int[5];

	// Use this for initialization
	void Start () {
		
		boosts[0] = Random.Range(1,5);		//Skin#
		boosts[1] = Random.Range(1,5);		//Health
		boosts[2] = Random.Range(1,5);		//Acceleration
		boosts[3] = Random.Range(1,5);		//MaxSpeed
		boosts[4] = Random.Range(1,5);		//TurnSpeed	
	}
	
	void OnTriggerEnter(Collider col){
		string curWep;
		string curWea;
		
		PlayerPrefs.SetString("Cool", "Cool");
		
		if(col.tag == "Player"){
			
			//Loop through weapons
			for(int i = 1; i <= 4; i++){
				curWep = "Weapon" + i;
				curWea = PlayerPrefs.GetString(curWep);
				Debug.Log("CurWep: " + curWep + "   " + curWea);
				
				if(curWea == ""){
					Debug.Log("setting" + curWep + "to " + toString());
					PlayerPrefs.SetString(curWep, toString());
					break;
				}
			}
		}
	}
	
	private string toString(){
		string printString = boosts[0] +":"+ boosts[1] +":" + boosts[2] +":" + boosts[3] +":" + boosts[4];
		return printString;
	}
}