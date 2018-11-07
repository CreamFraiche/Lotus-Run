using UnityEngine;
using System.Collections;

public class openingCamRotate : MonoBehaviour {

	public GameObject camera;
	public GameObject cube;
	public int frames;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(frames < 800){
			//Rotate horizontally
			cube.transform.Rotate(Vector3.up * Time.deltaTime * 13);
			
			//Vertically
			if(frames < 575){
				camera.transform.Rotate(Vector3.right * Time.deltaTime * 3);
			}
			
			//Move up
			if(frames > 260 && frames < 575){
			transform.Translate(Vector3.up * Time.deltaTime/2);
			}
		}
		frames++;
		if(frames > 1300){
			Application.LoadLevel("level1");
		}
	}
}