using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseGui : MonoBehaviour {


	Texture2D[] backgrounds= null;
	protected GUISkin skin;
	protected void Start () {
		backgrounds= new Texture2D[56];
		for (int x = 0; x<56; x++) {
			string file= String.Format("GUI/menu/sec_inicio_{0:00000}",x);
			backgrounds[x]=(Texture2D)Resources.Load(file);
		}
		skin=(GUISkin)Resources.Load("UserInterfaceSkin");

		Application.targetFrameRate = 20;
		
		
	} 
	private int currentImage=0;
	protected void OnGUI(){
		if(backgrounds!=null){
			if (currentImage >= backgrounds.Length)
					currentImage = 0;
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgrounds[currentImage]);
				currentImage++;
		}
		GUI.skin=skin;
		GUI.skin.label.fontSize=22;
		GUI.skin.button.fontSize=(int) (Screen.width * 0.04f);
		GUI.skin.button.wordWrap=true;
		GUI.skin.box.fontSize=(int) (Screen.width * 0.04f);
		GUI.skin.box.wordWrap = true;
		GUI.skin.label.wordWrap = true;
	}
	
	protected void Update () {
	
	}
	protected delegate void ButtonDelegate (string text);
	
	protected void addButtons(Dictionary<string,ButtonDelegate> data, Rect target){
		//GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f),title);

		float buttonHeight=((target.height*.9f)/(data.Count))-10f;
		float buttonWidth=target.width*.9f;
		int buttonNumber=0;
		foreach (KeyValuePair<string, ButtonDelegate> entry in data){
			if(GUI.Button(new Rect(target.left+(buttonWidth*.05f),(target.top+(target.height*.1f))+((buttonHeight+5f)*buttonNumber),buttonWidth,buttonHeight),entry.Key)){
				entry.Value(entry.Key);				
			}
			buttonNumber=buttonNumber+1;
		}
	}
}
