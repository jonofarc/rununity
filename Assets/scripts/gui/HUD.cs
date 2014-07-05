using UnityEngine;
using System.Collections;
using System.IO;

public class HUD : BaseGui {
	public GameObject player;//asignamos al player para regresarle valores cuadno la barra de hp este llena
	public GUIStyle pointsColor;
	public GUIStyle watermarkStyle;
	public bool musicOn;


	public static float hp=.5f;
	//public static float points=Random.Range(0f,1000f);
	public static float points;
	public static int sublvl;

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
		sublvl = GotoLvl.getSubLevel ();

		//pointsColor.normal.textColor = new Color(0,0,0);//asigan el color que se usara para el font de los puntos
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
		base.OnGUI();
		// jonathan agregado el puntaje y su estilo
		Texture2D pointst = (Texture2D)Resources.Load("GUI/HUD/puntos");
		GUI.DrawTexture(new Rect(10, 10, 196, 64),pointst );
		GUI.Label(new Rect(20, 30, 128, 64),points.ToString());
		/*"puntos:"+points.ToString(),points*/
		Texture2D levelt = (Texture2D)Resources.Load("GUI/HUD/nivel");
		GUI.DrawTexture(new Rect(210, 10, 64,64),levelt );
		GUI.contentColor=Color.blue;
		GUI.Label(new Rect(235, 30, 64,64),sublvl.ToString());
		GUI.contentColor=Color.white;

		//jonathan agregado el label de watermark y su estilo
		watermarkStyle.normal.background = (Texture2D)Resources.Load("UserInterface/capture_button_normal_XHigh");
		watermarkStyle.alignment= TextAnchor.MiddleCenter;
		GUI.Label (new Rect (Screen.width/2, Screen.height-70, 200, 60), "Version de Desarrollo", watermarkStyle);



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
			float fullHP=Screen.height*.69f,
				topHp=(Screen.height*.205f)+(fullHP-(fullHP*hp));
			Texture2D water_border = (Texture2D)Resources.Load("GUI/HUD/barra");
			GUI.DrawTexture(new Rect(Screen.width*.05f,Screen.height*.2f, Screen.width*.09f, Screen.height*.7f), water_border);

			Texture2D water = (Texture2D)Resources.Load("GUI/HUD/barra-azul");
			GUI.DrawTexture(new Rect(Screen.width*.06f,topHp, Screen.width*.07f, fullHP*hp), water);



		}
		
		if (Time.timeScale == 0) {
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .3f),
						(Screen.height / 2) - (Screen.height * .225f),
						Screen.width * .6f,
				Screen.height * sizeRatio), "Resumir")){
				Sound.playTheme(gameObject);
				Time.timeScale = 1;
			} 
				
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .3f),
						(Screen.height / 2) - (Screen.height * .075f),
						Screen.width * .6f,
						Screen.height * sizeRatio), "Reiniciar")) {
				Application.LoadLevel(Application.loadedLevel);
				Time.timeScale=1;
			}				
			if (GUI.Button (new Rect (
						(Screen.width / 2) - (Screen.width * .3f),
						(Screen.height / 2) - (Screen.height * -.075f),
						Screen.width * .6f,
						Screen.height * sizeRatio), "Menu")){
				Application.LoadLevel("Start");
				Time.timeScale=1;
			}

		}



	}

}
