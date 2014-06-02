#pragma strict
var moveSpeedx: float;
var moveSpeedy: float;
var moveSpeedz: float;
function Start () {

}

function Update () {

transform.Translate(moveSpeedx*Time.time,moveSpeedy*Time.time,moveSpeedz*Time.time);

}