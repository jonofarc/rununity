#pragma strict
public var speed=1;

function Start () {

}

function Update () {
this.transform.Translate(0,0,speed*Time.deltaTime);
}