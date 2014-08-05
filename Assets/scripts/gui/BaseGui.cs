using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseGui : MonoBehaviour {
	//jonathan vatriables para movimiento logo
	int logoAngle = 0;
	int side=1;
	int degreesMove=20;

	Texture2D[] backgrounds= null;
	protected GUISkin skin;
	protected void Start () {
		/*
		  backgrounds= new Texture2D[56];
		for (int x = 0; x<56; x++) {
			string file= String.Format("GUI/menu/sec_inicio_{0:00000}",x);
			backgrounds[x]=(Texture2D)Resources.Load(file);
		}
		skin=(GUISkin)Resources.Load("UserInterfaceSkin");

		Application.targetFrameRate = 20;
		*/
		skin=(GUISkin)Resources.Load("UserInterfaceSkin");
		backgrounds= new Texture2D[2];
		backgrounds[0] = (Texture2D)Resources.Load("GUI/fondoinicio");
		backgrounds[1] = (Texture2D)Resources.Load("GUI/Logo");



	} 
	private int currentImage=0;
	protected void OnGUI(){

		//jonathan nueva forma de dibhujar el background sin animacion por cambio de texturas
		GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height),backgrounds[0] );



		Matrix4x4 matrixBackup  = GUI.matrix;
		float thisAngle = logoAngle/4;
		logoAngle = logoAngle + side;
		if(logoAngle>(degreesMove*4)){
			side=-1;
			//logoAngle++;
		}
		if(logoAngle<-(degreesMove*4)){
			side=1;
			//logoAngle++;
		}


		Vector2 pos =  new Vector2(Screen.width/2, Screen.height/2);
		float posx =Screen.width;
		float posy =Screen.height;
		
		GUIUtility.RotateAroundPivot(thisAngle, pos);
		
		//all to be rotated put here
		//GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-50,200,50), "Upside down");  
		GUI.DrawTexture(new Rect(0, Screen.height/-2.2f, Screen.width/1,Screen.height/0.7f),backgrounds[1] );
		//end of rotated
		
		GUI.matrix = matrixBackup;

		/////////////////////////////////////////// fin de jonathan :P

		/*
		if(backgrounds!=null){
			if (currentImage >= backgrounds.Length)
					currentImage = 0;
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgrounds[currentImage]);
				currentImage++;
		}
		*/
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
