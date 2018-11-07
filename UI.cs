using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	//variables for health bar
	public Texture2D healthBarBackground;
	public Texture2D healthBarGreen;
	public Texture2D healthBarYellow;
	public Texture2D healthBarRed;
	private Vector2 size = new Vector2(604,45);
	private Vector2 pos = new Vector2(Screen.width/2 - 302,5);
	public float health = 1.0f;

	//variables for gui
	private int time;
	private int startTime;
	public Texture2D timerBackground;
	public GUIStyle timerStyle;
	private string guiText;
	private int score;
		
	public GUISkin skin;
	
	public void healthBar() {

		//create a group for the health bar
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));

			//create the background of the health bar
			GUI.Box (new Rect (0,0, size.x, size.y), healthBarBackground);
		
			//create the colored part of the health bar, the width of this bar changes when the health changes
			//if the health is greater than or equal to .8, use the green bar
			GUI.BeginGroup (new Rect (0,0, size.x*health, size.y));
				if (health >= .8) {
					GUI.Box (new Rect (0,0, size.x, size.y), healthBarGreen);
				}
				//if the health is between .3 and and .8, use the yellow bar
				if (health >= .3 && health < .8) {
					GUI.Box (new Rect (0,0, size.x, size.y), healthBarYellow);
				}
				//if the health is lower than .3, use the red bar
				if (health < .3) {
					GUI.Box (new Rect (0,0, size.x, size.y), healthBarRed);
				}
			//end gui group for colored bar
			GUI.EndGroup();
		//end group for the background of the bar
		GUI.EndGroup();
	}

	public void timer() {
		//create a group for the timer
		GUI.BeginGroup(new Rect(Screen.width / 2 - (timerBackground.width/2), 50, timerBackground.width, timerBackground.height));
			
			GUI.Box(new Rect(0,0,timerBackground.width, timerBackground.height), guiText, timerStyle);

		//end group for timer
		GUI.EndGroup();
	}
		
	void OnGUI() {
		//set the gui sking
		GUI.skin = skin;
		//draw the gui elements
		healthBar();
		timer();

	}


	// Use this for initialization
	void Start () {
		score = 0;
		time = 0;
		startTime = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		time = (int)Time.time - startTime;
		//guiTime = "Time:\n" 
		guiText = "Time: " + time + "    Score: " + score;
	}
	
	public void addScore(int points) {
		score += points;
	}

	public void takeDamage(float damage) {
		health -= damage;
	}
}