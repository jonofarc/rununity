#pragma strict

public var blackscreen: GameObject;
public var TouchText: GameObject;












function Start () {

}

function Update () {





if (Input.touchCount > 0){


		
		Invoke( "success", 2.0 );
		
		


		
		}


}

function OnMouseDown () {
	Debug.Log("lotoucheconclcick");
	

 
   
	//if(Time.timeScale>0){
	
	//Time.timeScale=0;
	//}
	//else{
	
	//Time.timeScale=1;
	
	//}	
	
	
	//if(cube.transform.localPosition.x>7){
		
	//	cube.transform.localPosition = new Vector3((1*Time.timeScale),cube.transform.position.y,cube.transform.position.z);
	//	}
		
		

Invoke( "success", 3.0 );
		


		

}
function success(){

		blackscreen.transform.localPosition = new Vector3(0,0.5,0);
		TouchText.SetActive(true);

}