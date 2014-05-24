using UnityEngine;
using System.Collections;
using System.IO;

public class HUD : MonoBehaviour {
	private static float hp=.1f;

	public static void setHP(float hp){
		HUD.hp=hp;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (Time.timeScale == 1) { 
			Texture2D pause = (Texture2D)Resources.Load("GUI/HUD/pause");
			if (GUI.Button (new Rect (Screen.width - (Screen.width * .15f),
				       Screen.height * .05f,
				       Screen.width * .1f,
				       Screen.height * .1f), pause)) 
				Time.timeScale = 0;
			float fullHP=Screen.height*.7f,
				topHp=(Screen.height*.15f)+(fullHP-(fullHP*hp));

			GUI.Box(new Rect(Screen.width*.05f,Screen.height*.15f,Screen.width*.05f, fullHP ),"");
			Texture2D water = (Texture2D)Resources.Load("GUI/HUD/water");
			GUI.DrawTexture(new Rect(Screen.width*.05f,topHp, Screen.width*.05f, fullHP*hp), water);
		}
		
		if (Time.timeScale == 0) {
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .05f),
						(Screen.height / 2) - (Screen.height * .225f),
						Screen.width * .1f,
						Screen.height * .1f), "Resumir")) 
				Time.timeScale = 1;
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .05f),
						(Screen.height / 2) - (Screen.height * .075f),
						Screen.width * .1f,
						Screen.height * .1f), "Reiniciar")) {
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale=1;
			}				
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .05f),
						(Screen.height / 2) - (Screen.height * -.075f),
						Screen.width * .1f,
						Screen.height * .1f), "Menu")){
				Application.LoadLevel("Start");
				Time.timeScale=1;
			}

		}



	}

}
