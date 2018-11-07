using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	//styles for the buttons
	public GUIStyle startButtonStyle;
	public GUIStyle instructionButtonStyle;
	public GUIStyle quitButtonStyle;

	//images
	public Texture2D backgroundTexture;
	public Texture2D startButtonTexture;
	public Texture2D quitButtonTexture;
	public Texture2D instructionButtonTexture;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		GUI.BeginGroup(new Rect (0, 0, Screen.width, Screen.height));
			
		GUI.Box(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		//button to start the game
		if (GUI.Button(new Rect (Screen.width/4 - (startButtonTexture.width), Screen.height - startButtonTexture.height, startButtonTexture.width, startButtonTexture.height), "", startButtonStyle)) {
			Application.LoadLevel("opening");
		}
		//button that will bring up the instructions
		if (GUI.Button(new Rect (Screen.width/2 - (instructionButtonTexture.width/2), Screen.height - instructionButtonTexture.height, instructionButtonTexture.width, instructionButtonTexture.height), "", instructionButtonStyle)) {

		}
		//quit button, this will only work in standalone mode, if we make it online only we should remove this
		if (GUI.Button(new Rect ((((Screen.width /8) * 7) - quitButtonTexture.width), Screen.height - quitButtonTexture.height, quitButtonTexture.width, quitButtonTexture.height), "", quitButtonStyle)) {
			Application.Quit();
		}


		GUI.EndGroup();
	}
}
