#pragma strict

function Start () {

}

function Update () {




}

function OnCollisionEnter(collision : Collision) {
		// Debug-draw all contact points and normals
	//Debug.Log(collision.transform.name);
	Debug.Log(collision.transform.name);
	if(collision.transform.name=="charraco(Clone)"){
	

		this.SendMessage("deadAnimation");
		Invoke( "restartLvl", 3.0 );
	
	}
	if(collision.transform.name=="gota_rescate(Clone)"){
	

		Destroy(collision.gameObject);
		this.SendMessage("speedBoost");
	
	}


}
function restartLvl(){

	Application.LoadLevel(Application.loadedLevel);

}