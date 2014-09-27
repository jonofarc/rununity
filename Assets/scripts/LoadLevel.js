#pragma strict

public var LevelToLoad : String;

function Start () {

}

function Update () {

}

function OnMouseDown () {
	Application.LoadLevel(LevelToLoad.ToString());
}