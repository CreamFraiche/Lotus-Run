using UnityEngine;
using System.Collections;

public class Buildings : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			//lower the speed of the player by 5%. Can be changed
			Player.curSpeed -= (Player.curSpeed * .5f);
			
			//Bounce the player back 5 units after colliding with a building. 
			c.transform.position = c.gameObject.GetComponent<Player>().getLastPos();   //new Vector3(c.transform.position.x -5 , c.transform.position.y,c.transform.position.z);			
		}
	}
}