#pragma strict

public var cube: GameObject;

var myImg : GUITexture;











function Start () {

}

function Update () {





if (Input.touchCount > 0){


	if (myImg.HitTest(Input.GetTouch(0).position))
    {
    		cube.transform.Translate(1,0,0);
       if(Input.GetTouch(0).phase==TouchPhase.Began)
       {
        	 print("Touch has began on image");
			 if(Time.timeScale>0){
	
			Time.timeScale=0;
		}
		else{
	
			Time.timeScale=1;
	
		}	
         
       }
       if(Input.GetTouch(0).phase==TouchPhase.Stationary)
       {
         print("Touch is on image");
       }
       if(Input.GetTouch(0).phase==TouchPhase.Moved)
       {
         print("Touch is moving on image");
       }
       if(Input.GetTouch(0).phase==TouchPhase.Ended)
       {
         print("Touch has been ended on image");
       }
    }
		
		
		if(cube.transform.localPosition.x>7){
		
		cube.transform.localPosition = new Vector3((1*Time.timeScale),cube.transform.localPosition.y,cube.transform.localPosition.z);
		}
		
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
	
	
	if(cube.transform.localPosition.x>7){
		
		cube.transform.localPosition = new Vector3((1*Time.timeScale),cube.transform.localPosition.y,cube.transform.localPosition.z);
		}
		cube.transform.Translate(1,0,0);
		

		
		


		

}