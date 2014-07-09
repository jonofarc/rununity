using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class MainMenu : BaseGui {
	bool loadingLevel=false;


	void Awake(){
					
		FBUtil.init();

	}
	bool leaderBoard=false;
	bool levelPicker=false;
	JSONNode scores;
	void OnGUI () {		
		base.OnGUI();
		if(leaderBoard){
			if(scores==null)
				leaderBoard=false;
			else{
				doLeaderBoard();
			}
		} else if(levelPicker){
			doLevelChooser();
		}else {
			doMainMenu();
		}
	}

	void Start () {
		loadingLevel=false;
		base.Start();
	}
	private int level=0;
	private void doLevelChooser(){
		Rect boxRect=new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f);
		GUI.Box(boxRect ,"Niveles");
		closeButton();
		Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
		if(level==0){
			for(int x=1;x<=5;x++){
				dic.Add("Nivel "+x,delegate(string text){
					level=Int32.Parse(text.Split(' ')[1]);
				});
			}
		}else{
			for(int x=1;x<=5;x++){
				dic.Add("Subnivel "+x,delegate(string text){
					PlayerPrefs.SetInt("level",level);
					PlayerPrefs.SetInt ("sublevel", (Int32.Parse(text.Split(' ')[1]))-1);
					GotoLvl.changeLevel();
				});

			}
		}



		addButtons(dic,boxRect);


	}
	private void closeButton(){
		Rect closeRect = new Rect ((Screen.width * .9f) - 32, (Screen.height * .1f), 32, 32);
		Texture2D closeText = (Texture2D)Resources.Load("close-button");
		GUI.DrawTexture(closeRect, closeText);
		if (GUI.Button (closeRect, "", new GUIStyle())) {
			leaderBoard=false;
			levelPicker=false;
			level=0;
		}
	}

	Dictionary<String, Texture2D> dicImages= new Dictionary<string, Texture2D>();
	private void doLeaderBoard(){
		GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f),"Puntuaciones(Primeros 10)");
		GUISkin sk =GUI.skin;
		sk.label.fontSize=11;


		float buttonHeight=((Screen.height*.75f)/10);
		float buttonWidth=Screen.width*.7f;
		closeButton();

		int count=0;
		//for (int x=0;x<10;x++)
		foreach (JSONNode node in scores["data"].AsArray){
			//{{"user":{"id":"660260877354538", "name":"Oscar Damian Velazquez"}, "score":"0", "application":{"name":"Run", "id":"252232634964826"}}}
			string userId=node["user"]["id"];
			if(!dicImages.ContainsKey(userId)){
				dicImages.Add(userId,null);
				StartCoroutine(userImage(userId));
			}

			if(dicImages[userId]!=null){
				Rect rect=new Rect(-5+(Screen.width*.15f),(Screen.height*.15f)+((buttonHeight)*count),buttonWidth*.1f,16f);
				GUI.DrawTexture(rect,dicImages[userId]);
			}
			GUI.Label(new Rect((Screen.width*.08f)+(buttonWidth*.1f),(Screen.height*.15f)+((buttonHeight)*count),buttonWidth*.8f,buttonHeight),node["score"],sk.label);
			GUI.Label(new Rect((Screen.width*.15f)+(buttonWidth*.2f),(Screen.height*.15f)+((buttonHeight)*count),buttonWidth*.8f,buttonHeight),node["user"]["name"],sk.label);
			


			count=count+1;
		}
	}
	private IEnumerator userImage(string userId){
		WWW url = new WWW("https" + "://graph.facebook.com/" + userId + "/picture?type=large"); //+ "?access_token=" + FB.AccessToken);
		yield return url;
		Texture2D texture = new Texture2D(32, 32, TextureFormat.DXT1, false);
		url.LoadImageIntoTexture (texture);
		dicImages[userId]=texture;	
	}



  private void doMainMenu(){

	if(loadingLevel==false){

		float boxHeigt = Screen.height*.5f, 
		boxWidth = Screen.width*.8f,
		boxLeft = Screen.width*.1f, 
		boxTop=Screen.height*.97f-boxHeigt,
		buttonWidth=boxWidth*.9f,
		buttonHeigth=(boxHeigt/6)-5f,
		buttonLeft = boxLeft+boxWidth*.05f,
		buttonTop=boxHeigt/6f;
		
		GUI.Box(new Rect(boxLeft,boxTop,boxWidth,boxHeigt), "Menu");
				
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop,buttonWidth,buttonHeigth), "Nueva partida")) {
			loadingLevel=true;
			PlayerPrefs.SetInt ("level", 1);
			PlayerPrefs.SetInt ("sublevel", 0);
			GotoLvl.currentsubLvls=0;
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*2,buttonWidth,buttonHeigth), "Continuar!!!")) {
			loadingLevel=true;
			GotoLvl.setSubLevel();
			GotoLvl.changeLevel(true);
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*3,buttonWidth,buttonHeigth), "Escoger nivel")) {
				levelPicker=true;
				leaderBoard=false;
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*4,buttonWidth,buttonHeigth), "LeaderBoard")) {
			FBUtil.friendsScores(delegate(FBResult result) {
				 scores=JSON.Parse(result.Text);
				leaderBoard=true;
				levelPicker=false;
			});
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*5,buttonWidth,buttonHeigth), "Compartir en Facebook")) {
			FBUtil.share(delegate {
				
			});	
		}
	}
	else{
			
			
		GUI.Label(new Rect(Screen.width*0.5f, Screen.height*0.5f, Screen.width, Screen.height*0.13f), "Cargando...");
			
			
	}


  }

	
	
}
