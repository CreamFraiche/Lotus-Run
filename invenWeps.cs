using UnityEngine;
using System.Collections;

public class invenWeps{
	//this class is used by the newInven.cs
	//this is where the weapons are created, stats are set and recieved.
	//this weapon is in the inventory, and does not get attached to any objects.

	private int[] stats = new int[5];

	public void create(){//called when new weapon is needed
		//setup stats
		stats [0] = Random.Range (0, 5);//skin
		stats [1] = Random.Range (5, 21);//hp
		stats [2] = Random.Range (5, 21);//acc
		stats [3] = Random.Range (5, 21);//maxspeed
		stats [4] = Random.Range (5, 21);//strafespeed
	}

	public int getStat(string s){
		switch (s){
			case "skin" : return stats[0];
			case "hp" : return stats[1];
			case "acc" : return stats[2];
			case "mSpeed" : return stats[3];
			case "sSpeed" : return stats[4];
		}
		return 99;//Error code
	}
	
	public int[] getArr(){
		return stats;
	}
}
