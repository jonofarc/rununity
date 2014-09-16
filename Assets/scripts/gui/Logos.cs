using UnityEngine;
using System.Collections;

public class Logos : MonoBehaviour {

	// Use this for initialization
	Texture2D luis;
	Texture2D xholo;
	float init;
	void Start () {
		xholo=(Texture2D)Resources.Load("logos/xholo");
		luis=(Texture2D)Resources.Load("logos/luis");
	}
	void OnGUI(){
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		int top=(Screen.height/2)-128;
		int left=(Screen.width/2)-128;
		if(init==null)
			init=Time.time;
		if((init+4)>Time.time)
			GUI.DrawTexture (new Rect (left,top,256, 256), luis, ScaleMode.StretchToFill);
		else if((init+8)>Time.time)
			GUI.DrawTexture (new Rect (left, top, 256, 256), xholo, ScaleMode.StretchToFill);
		else if ((init+12)>Time.time)
			Application.LoadLevel("VideoIntro");
		
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();



	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
