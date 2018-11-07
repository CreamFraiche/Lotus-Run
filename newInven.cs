using UnityEngine;
using System.Collections;

public class newInven : MonoBehaviour {
	//this inventory class is where all of the weapons are stored.
	// this class goes on the inventory object in the startmenu scene.
	//will need to apply the gui information from the old inventory script.

	private int maxInvenSize;//maximum amount of weapons in the inventory
	public int equipedWeapon;
	public invenWeps[] inven;//the inventory itself
	
	void Start () {
		equipedWeapon = 0;
		DontDestroyOnLoad (this);
		maxInvenSize = 4;//set size
		inven  = new invenWeps[maxInvenSize];
		inven [0] = new invenWeps ();
		inven [0].create ();//create the weapon
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void add(GameObject g){
		int L = inven.Length;

		if(L < maxInvenSize){//if current size is less than max size
			inven[L] = new invenWeps();//create new weapon in this position
			inven[L].create();//copy all stats from previous GameObject weapon
		}
		Destroy (g);//destroy the floating weapon. It has outlived it's usefulness.
	}
	
	public void set(GameObject g){

			inven[0] = new invenWeps();//create new weapon in this position
			inven[0].create();//copy all stats from previous GameObject weapon

		Destroy (g);//destroy the floating weapon. It has outlived it's usefulness.
	}

	public string getItemStats(int itemPos){
		Debug.Log("Getting from the inventory at " + itemPos);
		invenWeps w = inven [itemPos];
		string s = "Acceleration: " + w.getStat ("acc");
		s += "\nMax Speed: " + w.getStat ("mSpeed");
		s += ", Strafe Speed: " + w.getStat ("sSpeed");
		return s;
	}
	
	public int[] getCurStats(int position = 10){
		if(position == 10){
			position = equipedWeapon;
		}
		
		Debug.Log (getItemStats (0));
		invenWeps w = inven[position];
		if ( w == null){
			Debug.Log("W is null!!!!");
			Debug.Log("curWep = " + position);
		}
		int[] stats = w.getArr();
		
		return stats;
	}
	
	public void setEquiped(int pos){
		equipedWeapon = pos;
	}
	
	public int getEquiped(){
		return equipedWeapon;
	}
}