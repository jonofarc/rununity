using UnityEngine;
using System.Collections;
using System.IO;

public class HUD : MonoBehaviour {
	public GameObject player;//asignamos al player para regresarle valores cuadno la barra de hp este llena

	public static float hp=.5f;

	public static void setHP(float hp){
		HUD.hp=hp;
	}
	// Use this for initialization
	void Start () {
		hp=0f;//inisialisamos la variable por si el nivel es reiniciado con el menu o por morir
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//esta funcion es llamada desde el objeto Gonti_run en el script colliderDetection.js al obtener una gotita
	 void increaseHP(){
		if(hp<0.9f){
			hp=hp+0.1f;

		}
		else{
			hp=1f;
			player.SendMessage("hpMaxed");
		}

	}
	//esta funcion es llamada desde el objeto Gonti_run en el script colliderDetection.js al obtener una gotita
	void decreaseHP(){
	
		hp=0f;
		
		
	}
	float sizeRatio=.15f;
	void OnGUI(){
		if (Time.timeScale == 1) { 
			Texture2D pause = (Texture2D)Resources.Load("GUI/HUD/pause");
			if (GUI.Button (new Rect (Screen.width - (Screen.width * .15f),
				       Screen.height * .05f,
				       Screen.width * sizeRatio,
				       Screen.height * sizeRatio), pause)) 
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
						Screen.width * sizeRatio,
						Screen.height * sizeRatio), "Resumir")) 
				Time.timeScale = 1;
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .05f),
						(Screen.height / 2) - (Screen.height * .075f),
						Screen.width * sizeRatio,
						Screen.height * sizeRatio), "Reiniciar")) {
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale=1;
			}				
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .05f),
						(Screen.height / 2) - (Screen.height * -.075f),
						Screen.width * sizeRatio,
						Screen.height * sizeRatio), "Menu")){
				Application.LoadLevel("Start");
				Time.timeScale=1;
			}

		}



	}

}
