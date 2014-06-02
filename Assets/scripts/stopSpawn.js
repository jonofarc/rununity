#pragma strict
public var mySpawnController: GameObject;

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
		//mySpawnController.active=false;
		mySpawnController.SetActive(false);
		Destroy(this.gameObject);
}