using UnityEngine;
using System.Collections;
public class MainMenu : MonoBehaviour {

	void Awake(){
		enabled = false;
		FB.Init(delegate {
			//init
			enabled = true; // "enabled" is a property inherited from MonoBehaviour
			if (FB.IsLoggedIn){
				FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, FBCallback);
			}
		}, delegate {
			//en ejemplo pusieron cosas pusieron logica pause aqui
		});
	}
	void FBCallback(FBResult result)
	{

		
		//parsear cadena o tronar por que no pudo
		//GameStateManager.Username = profile["first_name"];
		//friends = Util.DeserializeJSONFriends(result.Text);
	}



	void OnGUI () {
	
		Texture2D texture = (Texture2D)Resources.Load("batsi");
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
		float boxHeigt = Screen.height*.25f, 
			boxWidth = Screen.width*.25f,
			boxLeft = Screen.width*.9f - boxWidth, 
			boxTop=Screen.height*.9f-boxHeigt,
			buttonWidth=boxWidth*.9f,
			buttonHeigth=boxHeigt*.2f,
			buttonLeft = boxLeft+boxWidth*.05f,
			buttonTop=boxHeigt/4f;

		GUI.Box(new Rect(boxLeft,boxTop,boxWidth,boxHeigt), "Algo de gonti");
		
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop,buttonWidth,buttonHeigth), "Video")) {
			Application.LoadLevel(0);
		}
		
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*2,buttonWidth,buttonHeigth), "Demo")) {
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect(buttonLeft,boxTop+buttonTop*3,buttonWidth,buttonHeigth), "Face")) {
			if (!FB.IsLoggedIn)
				FB.Login("email,publish_actions", delegate {
					Debug.Log("login");
				});
		}
	}


}
