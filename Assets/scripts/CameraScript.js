#pragma strict
public var myPlayer: GameObject;

function Start () {

}

function Update () {

this.transform.position= new Vector3 (3.86,3,(myPlayer.transform.position.z-6));

} 