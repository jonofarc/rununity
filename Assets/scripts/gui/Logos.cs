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
		if(init==null)
			init=Time.time;
		if((init+4)>Time.time)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), luis);
		else if((init+8)>Time.time)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), xholo);
		else if ((init+12)>Time.time)
			Application.LoadLevel("VideoIntro");
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
