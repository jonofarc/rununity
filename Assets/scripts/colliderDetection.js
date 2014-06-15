#pragma strict
public var myCamera: GameObject;
private var lvlFinished: boolean;
private var moveBack: float;
public var moveBackObject: GameObject;


function Start () {
lvlFinished=false;
moveBack=-1f;
}

function Update () {


	//move back section for enemies that push you back

	if(Time.time<moveBack){
	Debug.Log("entre");
		this.transform.Translate(0,0,-15*Time.deltaTime);
		
	}
	else if(moveBackObject!=null){
		moveBackObject.SetActive(false);
	}


if(lvlFinished==true){
transform.eulerAngles = Vector3(0,180,0);
}
	

}

function OnCollisionEnter(collision : Collision) {
		// Debug-draw all contact points and normals
//	Debug.Log(collision.transform.tag);
//	Debug.Log(collision.transform.name);
	if(collision.transform.tag=="badSpawn"){
	
		Destroy(collision.gameObject);
		this.SendMessage("deadAnimation");	
		myCamera.SendMessage("decreaseHP");
		
	
	}
	if(collision.transform.tag=="badSpawn2"){
	
		Destroy(collision.gameObject);
		this.SendMessage("deadAnimation");	
		myCamera.SendMessage("decreaseHP");
		moveBack=Time.time+3;
		if(moveBackObject!=null){
			moveBackObject.SetActive(true);
		}
	
	}
	if(collision.transform.tag=="goodSpawn"){
	

		Destroy(collision.gameObject);
		this.SendMessage("speedBoost");
		myCamera.SendMessage("increaseHP");
	
	}
	if(collision.transform.name=="LvlFinished"){
	

				lvlFinished=true;
				//Destroy(collision.gameObject);
				
				collision.gameObject.SendMessage("lvlFinished");
				this.SendMessage("lvlFinished");
				
				
		
	
	}




	

}





