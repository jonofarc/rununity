using UnityEngine;
using System.Collections;
using System.IO;

public class HUD : MonoBehaviour {
	public GameObject player;//asignamos al player para regresarle valores cuadno la barra de hp este llena
	public GUIStyle pointsColor;
	public bool musicOn;


	public static float hp=.5f;
	//public static float points=Random.Range(0f,1000f);
	public static float points;
	public static float getPoints(){
		return points;
	}

	public static void setHP(float hp){
		HUD.hp=hp;

	}
	public void setPoints(){

		if (hp < 1) {
		    points = points + (Mathf.Pow (2, (hp * 10)));
		} 
		else {
		
			points = points + ((Mathf.Pow (2, (hp * 10)))*2);

		}

	//	Debug.Log (points);
	
	}
	void jumpStart(){
		Sound.playTrack(gameObject,"jump");
	}

	// Use this for initialization
	void Start () {
		hp=0.0f;//inisialisamos la variable por si el nivel es reiniciado con el menu o por morir
		points=0f; // idem
		pointsColor.normal.textColor = new Color(0,0,0);//asigan el color que se usara para el font de los puntos
		if(musicOn==true){
			Sound.playTheme (gameObject);
		}

		Application.targetFrameRate = -1;



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//esta funcion es llamada desde el objeto Gonti_run en el script colliderDetection.js al obtener una gotita
	 void increaseHP(){
		Sound.playTrack(gameObject,"suck");
		if(hp<0.9f){
			hp=hp+0.1f;

		}
		else{
			hp=1f;
			player.SendMessage("hpMaxed");
	

				points=points+500;

		}

	}
	//esta funcion es llamada desde el objeto Gonti_run en el script colliderDetection.js al obtener una gotita
	void decreaseHP(){
		Sound.playTrack(gameObject,"splash");
		hp=0f;
		
		
	}
	float sizeRatio=.1f;
	void OnGUI(){

		GUI.Label(new Rect(10, 10, 150, 150), points.ToString(),pointsColor);

		if (Time.timeScale == 1) { 
			Texture2D pauset = (Texture2D)Resources.Load("GUI/HUD/pause");
			Rect pauser=new Rect (Screen.width - (Screen.width * .15f),
			                      Screen.height * .05f,
			                      Screen.width * sizeRatio,
			                      Screen.height * sizeRatio);
			GUI.DrawTexture(pauser,pauset);
			if (GUI.Button (pauser, "", new GUIStyle())){ 
				Time.timeScale = 0;
				Sound.pauseTheme(gameObject);
			}
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
				Screen.height * sizeRatio), "Resumir")){
				Sound.playTheme(gameObject);
				Time.timeScale = 1;
			} 
				
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
