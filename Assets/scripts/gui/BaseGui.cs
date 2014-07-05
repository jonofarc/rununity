using UnityEngine;
using System.Collections;
using System;

public class BaseGui : MonoBehaviour {


	Texture2D[] backgrounds= null;
	protected Font font= null;
	protected void Start () {
		backgrounds= new Texture2D[56];
		for (int x = 0; x<56; x++) {
			string file= String.Format("GUI/menu/sec_inicio_{0:00000}",x);
			backgrounds[x]=(Texture2D)Resources.Load(file);
		}
		font=(Font)Resources.Load("GUI/LDFComicSans");
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
		GUI.skin.label.fontSize=22;
		GUI.skin.font=font;
		GUI.skin.button.fontSize=(int) (Screen.width * 0.04f);
		GUI.skin.button.wordWrap=true;
		GUI.skin.box.fontSize=(int) (Screen.width * 0.04f);
		GUI.skin.box.wordWrap = true;
		GUI.skin.label.wordWrap = true;
	}
	
	protected void Update () {
	
	}
}
