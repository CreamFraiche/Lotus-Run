using UnityEngine;
using System.Collections;

public class enemyTrigger : MonoBehaviour {
	public bool jump, move;							//Enables jumping and moving
	public float rReact, rPerfect, rGood, rMiss;	//Range for each zone
	public Vector3 jumpPoint;						//Enemy jumps to this location if jump is enabled
	public float distance;							//Distance to travel from start
	public int points;								//Points awarded for perfect kill
	private Vector3 startPoint;						//Starting location
	private int direction;							//Direction enemy is traveling
	public Font newfont;
	public Material fontMaterial;
	public Animation anim;
	public GameObject model;
	public bool attack = false;
	
	//Initialization stuff
	void Start () {
		startPoint = transform.position;
		direction = 1;
		Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		anim = model.GetComponent<Animation>();
	}
	
	//While something is colliding with this
	void OnTriggerStay (Collider other) {
		if(other.tag == "Player") {
			if(!attack){
				anim.Play("Attack_01");
				attack = true;
			}
			
			//Distance between the player and this enemy
			float d = Vector3.Distance(other.transform.position,transform.position);
			
			//Combat
			if(d < rReact) {
				if(d > rPerfect) {
					//Too early
					renderer.material.color = Color.red;
					if(Input.GetMouseButtonDown(0) && Player.attack()) {
						hit(3, other);
						showRating("Early");
					}
				}
				else if(d > rGood) {
					//Perfect Strike
					renderer.material.color = Color.green;
					if(Input.GetMouseButtonDown(0) && Player.attack()) {
						hit(0,other);
						showRating("Perfect");
					}
				}
				else if(d > rMiss) {
					//Good Strike
					renderer.material.color = Color.blue;
					if(Input.GetMouseButtonDown(0) && Player.attack()) {
						hit(1,other);
						showRating("Good");
					}
				}
				else {
					//Too late
					renderer.material.color = Color.black;
					hit(5,other);
					showRating("Late");
				}
			}
			else {
				//Reset color if player leaves range
				renderer.material.color = Color.white;
			}
		}
	}
	
	//Enemy reacts to being attacked by player
	// type: 0 = perfect, 1 = good, 2 = miss
	public void hit(int type, Collider other) {
		//Damage player
		StartCoroutine (wait (type, other));
		
	}
	
	//Moves enemy side to side if they move
	public void Update() {
		if (move) {
			if (Mathf.Abs(startPoint.z - transform.position.z) > distance) {
				direction = direction*(-1);
			}
			
			transform.Translate(new Vector3(0,0,0.05f*direction));
		}
	}
	
	public void showRating(string rating){
		
		GameObject myTextObject = new GameObject("rating");
		myTextObject.transform.position = this.transform.position;
		myTextObject.AddComponent("TextMesh");
		myTextObject.AddComponent("MeshRenderer");
		
		myTextObject.transform.Rotate(0, 90, 0);
		myTextObject.transform.Translate(Vector3.up * 5); 
		myTextObject.transform.Translate(Vector3.forward * 6); 
		
		TextMesh textMeshComponent = myTextObject.GetComponent(typeof(TextMesh)) as TextMesh;
		MeshRenderer meshRendererComponent = myTextObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
		Material[] mats = new Material[] {fontMaterial};
		 
		textMeshComponent.font = newfont;
		textMeshComponent.text = rating;
		
		meshRendererComponent.materials = mats;
	}
	
	IEnumerator wait(int type, Collider other){
		anim.Play("Die");
		yield return new WaitForSeconds(0.3f);
		other.GetComponent<UI>().takeDamage (type*.05f);
		//Die or jump forward
		if (jump && type != 0) {
			transform.position = jumpPoint;
			jump = false;
			renderer.material.color = Color.white;
		}
		else {
			if (type == 0) {
				other.GetComponent<UI>().addScore (points);
			}
			else if (type == 1) {
				other.GetComponent<UI>().addScore (points/2);
			}
			Destroy (gameObject);
		}
	}
}