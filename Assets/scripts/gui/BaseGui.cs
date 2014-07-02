using UnityEngine;
using System.Collections;
using System;

public class BaseGui : MonoBehaviour {


	Texture2D[] backgrounds= new Texture2D[56];
	protected Font font= null;
	protected void Start () {
		for (int x = 0; x<56; x++) {
			string file= String.Format("GUI/menu/sec_inicio_{0:00000}",x);
			backgrounds[x]=(Texture2D)Resources.Load(file);
		}
		font=(Font)Resources.Load("GUI/LDFComicSans");
		Application.targetFrameRate = 20;
		
		
	} 
	private int currentImage=0;
	protected void OnGUI(){
		if (currentImage >= backgrounds.Length)
			currentImage = 0;
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgrounds[currentImage]);
		currentImage++;
		GUI.skin.font=font;
		GUI.skin.button.fontSize=33;
		GUI.skin.button.wordWrap=true;
		GUI.skin.box.fontSize=40;
		GUI.skin.box.wordWrap = true;
		GUI.skin.label.wordWrap = true;
	}
	
	protected void Update () {
	
	}
}
