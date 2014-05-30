#pragma strict
public var mySpawnController: GameObject;

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
		mySpawnController.active=false;
		Destroy(this.gameObject);
}