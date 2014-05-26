#pragma strict

function Start () {

}

function Update () {




}

function OnCollisionEnter(collision : Collision) {
		// Debug-draw all contact points and normals
	//Debug.Log(collision.transform.name);
	
	if(collision.transform.name=="Cylinder(Clone)"){
	
	Debug.Log(collision.transform.name);
	this.SendMessage("deadAnimation");
	Invoke( "restartLvl", 3.0 );

	//Application.LoadLevel(Application.loadedLevel);
	
	}
	//Application.LoadLevel(Application.loadedLevel);

}
function restartLvl(){

	Application.LoadLevel(Application.loadedLevel);

}