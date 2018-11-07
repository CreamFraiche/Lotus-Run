using UnityEngine;
using System.Collections;

public class delaySound : MonoBehaviour {

	public int frames;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		frames++;
		if(frames == 150){
			audio.Play();
		}
	}
}
