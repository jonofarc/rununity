#pragma strict
public var mySpawnController: GameObject;
public var myLvlFinished: GameObject;

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
		//mySpawnController.active=false;

		myLvlFinished.renderer.material.mainTextureScale = Vector2 (1,1);
		mySpawnController.SetActive(false);
		Destroy(this.gameObject);
}