using UnityEngine;
using System.Collections;

public class Logos : MonoBehaviour {

	// Use this for initialization
	Texture2D luis,xholo,logo1,logo2;

	float init;
	void Start () {
		logo1=(Texture2D)Resources.Load("logos/logo1");
		logo2=(Texture2D)Resources.Load("logos/logo2");
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
		if((init+3)>Time.time)
			GUI.DrawTexture (new Rect (left,top,256, 256), logo1, ScaleMode.StretchToFill);
		else if((init+6)>Time.time)
			GUI.DrawTexture (new Rect (left, top, 256, 256), logo2, ScaleMode.StretchToFill);
		else if ((init+9)>Time.time)
			GUI.DrawTexture (new Rect ((Screen.width/2)-240, top, 480, 256), luis, ScaleMode.StretchToFill);
		else if ((init+12)>Time.time)
			GUI.DrawTexture (new Rect (left, top, 256, 256), xholo, ScaleMode.StretchToFill);
		else if ((init+15)>Time.time)
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
