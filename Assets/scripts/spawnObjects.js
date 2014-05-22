#pragma strict

public var myPlayer: GameObject;
public var Spawneable : Transform;
var passedTime : float;



function Start () {
passedTime= Time.time+3;
}

function Update () {

if(Time.time>passedTime){

passedTime= Time.time+1;
//Invoke( "success", 3.0 );
success();
}




}

function success(){
var carril = Random.Range(1,4)*2;
Instantiate (Spawneable, new Vector3(carril,myPlayer.transform.position.y+3,(myPlayer.transform.position.z+10)), Quaternion.identity);

}