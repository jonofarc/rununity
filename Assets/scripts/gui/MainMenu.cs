using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class MainMenu : MonoBehaviour {


	void Awake(){
					
		FBUtil.init();
	}
	bool leaderBoard=false;
	JSONNode scores;
	void OnGUI () {		
		Texture2D texture = (Texture2D)Resources.Load("GUI/menu/batsi");
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
		GUI.skin.button.fontSize=14;
		GUI.skin.button.wordWrap=true;
		GUI.skin.box.fontSize=16;
		GUI.skin.box.wordWrap = true;
		GUI.skin.label.wordWrap = true;
		if(leaderBoard){
			if(scores==null)
				leaderBoard=false;
			else{
				doLeaderBoard();
			}
		}else{
			doMainMenu();
		}
	}

	Dictionary<String, Texture2D> dicImages= new Dictionary<string, Texture2D>();
	private void doLeaderBoard(){
		GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f),"Puntuaciones(Primeros 10)");
		GUI.skin.button.fontSize=16;
		GUI.skin.button.wordWrap = true;
		float buttonHeight=((Screen.height*.75f)/10);
		float buttonWidth=Screen.width*.7f;
		Texture2D closeText = (Texture2D)Resources.Load("close-button");
		Rect closeRect = new Rect ((Screen.width * .9f) - 32, (Screen.height * .1f), 32, 32);
		GUI.DrawTexture(closeRect, closeText);
		if (GUI.Button (closeRect, "", new GUIStyle ())) {
			leaderBoard=false;
		}
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
			GUI.Label(new Rect((Screen.width*.15f)+(buttonWidth*.1f),(Screen.height*.15f)+((buttonHeight)*count),buttonWidth*.1f,buttonHeight),node["score"]);
			GUI.Label(new Rect((Screen.width*.15f)+(buttonWidth*.2f),(Screen.height*.15f)+((buttonHeight)*count),buttonWidth*.8f,buttonHeight),node["user"]["name"]);
			


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
		float boxHeigt = Screen.height*.4f, 
		boxWidth = Screen.width*.4f,
		boxLeft = Screen.width*.97f - boxWidth, 
		boxTop=Screen.height*.97f-boxHeigt,
		buttonWidth=boxWidth*.9f,
		buttonHeigth=-5f+boxHeigt*.2f,
		buttonLeft = boxLeft+boxWidth*.05f,
		buttonTop=boxHeigt/5f;
		
		GUI.Box(new Rect(boxLeft,boxTop,boxWidth,boxHeigt), "Algo de gonti");
		
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop,buttonWidth,buttonHeigth), "Video")) {
			Application.LoadLevel(0);
		}
		
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*2,buttonWidth,buttonHeigth), "Demo")) {
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*3,buttonWidth,buttonHeigth), "LeaderBoard")) {
			FBUtil.friendsScores(delegate(FBResult result) {
				 scores=JSON.Parse(result.Text);
				leaderBoard=true;

			});
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*4,buttonWidth,buttonHeigth), "Compartir en Facebook")) {
			FBUtil.share(delegate {
				
			});	
		}
	}

	
	
}
