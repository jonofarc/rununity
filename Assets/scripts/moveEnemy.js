#pragma strict
var moveSpeed: int;
function Start () {

}

function Update () {

transform.Translate(0,0,moveSpeed*Time.time);

}