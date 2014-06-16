#pragma strict

public var blackscreen: GameObject;
public var TouchText: GameObject;
public var videoDuration: float;












function Start () {

}

function Update () {





if (Input.touchCount > 0){


		
		Invoke( "success", 3.0 );
		//Invoke( "loadlvl", 40.0 );
		Invoke( "loadlvl", videoDuration );
		
		


		
		}


}

function success(){

		blackscreen.transform.localPosition = new Vector3(0,5.5,0);
		TouchText.SetActive(true);
		

}
function loadlvl(){

	Application.LoadLevel("Start");
		

}

function OnGUI(){

var matrixBackup:Matrix4x4  = GUI.matrix;
var thisAngle:float = 270;
var pos:Vector2 = Vector2(Screen.width/2, Screen.height/2);
var posx: float=Screen.width;
var posy: float=Screen.height;
 
GUIUtility.RotateAroundPivot(thisAngle, pos);
 
//all to be rotated put here
//GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-50,200,50), "Upside down");  
		if(GUI.Button(new Rect(posx*0.65,posy*0.65,50,50), "Saltar")) {
			Application.LoadLevel(1);
		}
//end of rotated
 
GUI.matrix = matrixBackup;
		
}