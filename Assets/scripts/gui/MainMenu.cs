using UnityEngine;
using System.Collections;
public class MainMenu : MonoBehaviour {


	void Awake(){
					
		FBUtil.init();
	}
	void OnGUI () {		
		Texture2D texture = (Texture2D)Resources.Load("GUI/menu/batsi");
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
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
			FBUtil.friendsScores();
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*4,buttonWidth,buttonHeigth), "Compartir en Facebook")) {
			FBUtil.share(delegate {

			});	
		}

	}

	
	
}
