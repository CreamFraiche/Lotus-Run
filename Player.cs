using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	
	public static float speed;		//Acceleration
	public static float maxSpeed;	//Max Speed
	public static int agility;	//Turn Speed
	public static int cooldown;			//If > 0, can't attack. Should be used in conjunction with attack animation when Sam's model is added
	public GameObject particles;	//Particle effect when at full speed
	float timePosUpdate;
	Vector3 lastPos;
	public static float curSpeed = 2.0f;
	public int[] stats;
	public static Animation anim;
	
	// Use this for initialization
	void Start () {
		timePosUpdate = Time.time;
				
		cooldown = 0;		//Starting value
		curSpeed = 4;
		stats = GameObject.FindGameObjectWithTag("inventory").GetComponent<newInven>().getCurStats();
		//hp = stats[0];
		speed = (float) stats[2]/1200f; //acc
		maxSpeed = stats[3] + 10;
		agility = stats[4];
		anim = GameObject.FindGameObjectWithTag("samurai").GetComponent<Animation>();
	}
	
	void Update () {
	
		//Run forward
		transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
		
		if (Time.time > timePosUpdate) {
			recLastPos();
		}
		//Decrement cooldown
		if (cooldown > 0) {
			cooldown--;
		}
		else{
			anim.Play("Run");
		}
		
		//Increase, but limit speed
		if (curSpeed < maxSpeed) {
			particles.active = false;
			curSpeed += speed;
		}
		else if (curSpeed > maxSpeed){
			//At max speed. Would like an effect here to show user
			particles.active = true;
			curSpeed = maxSpeed;
		}
		
		//Strafe left or right
		if(Input.GetKey("a")){
			transform.Translate(Vector3.left * agility* Time.deltaTime);
		}
		if(Input.GetKey("d")){
			transform.Translate(Vector3.right * agility * Time.deltaTime);
		}
	}
	
	
	void recLastPos(){
		lastPos = transform.position;
		timePosUpdate += .5f;
	}
	
	public Vector3 getLastPos(){
		return lastPos;
	}
	
	//Sets a cooldown for the player's attacks when the mouse is clicked near an enemy
	public static bool attack() {
		if (cooldown == 0) {
			anim["Attack"].time = 0.8F;
			anim.Play("Attack");
			cooldown = 45;
			return true;
		}
		else {
			return false;
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "finish"){
			int level = PlayerPrefs.GetInt("CurrentLevel");
			level++;
			PlayerPrefs.SetInt("CurrentLevel", level);
			Application.LoadLevel("inventory");
		}
	}
}