using UnityEngine;
using System.Collections;

public class newWeapon : MonoBehaviour {

	//this is the class for new objects/weapons. They will be on the screen/field and interact with the player
	//this class does nothing except make an object float up and down, and tell the inventory to create a new weapon.
	//place this on the weapons prefab

	// stats
	private double timer;		//timer for movement/floating
	private float yChange;		//distance y will change
	private float baseY;		//the y position object started at.


	// Use this for initialization
	void Start () {
		yChange = .05f;
		timer = Time.time + .01f;
		baseY = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		//make object float up and down.
		if(Time.time >= timer){
			transform.position = new Vector3(transform.position.x,transform.position.y + yChange , transform.position.z);

			if((transform.position.y >= (baseY+2.5)) || (transform.position.y < baseY)){//if y is greater than base+2.5 or less than base, change the direction
				yChange = -1*yChange;//set yChange to opposite
			}
			timer = Time.time + .01;
		}
	}

	//on collision make inventory create new weapon
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			GameObject.FindGameObjectWithTag("inventory").GetComponent<newInven>().set(this.gameObject);// add a weapon to the inventory
		}
	}
}