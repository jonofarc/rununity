#pragma strict
public var myCamera: GameObject;
public var lvlFinished: boolean;


function Start () {
lvlFinished=false;
}

function Update () {

if(lvlFinished==true){
transform.eulerAngles = Vector3(0,180,0);
}
	

}

function OnCollisionEnter(collision : Collision) {
		// Debug-draw all contact points and normals
	//Debug.Log(collision.transform.name);
	Debug.Log(collision.transform.name);
	if(collision.transform.name=="charraco(Clone)"){
	
		Destroy(collision.gameObject);
		this.SendMessage("deadAnimation");	
		myCamera.SendMessage("decreaseHP");
		
	
	}
	if(collision.transform.name=="gotita_rescate3(Clone)"||collision.transform.name=="gota_rescate(Clone)"){
	

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




