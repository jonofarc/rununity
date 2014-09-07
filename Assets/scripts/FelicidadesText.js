#pragma strict

var my3DText : GameObject;

function Start () {

}

function Update () {

}
function FinishText () {

	my3DText.SetActive(true);
	my3DText.GetComponent(TextMesh).text = "   Nivel "+(PlayerPrefs.GetInt("sublevel")+1)+" \nTerminado ";
	

}