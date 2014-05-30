#pragma strict
public var myPlayer: GameObject;
public var myObject: GameObject;


function Start () {

}

function Update () {

if(myPlayer.transform.position.z>(myObject.transform.position.z+10)){
Destroy (myObject);

}

if(myObject.transform.position.y<-1){

myObject.transform.position= new Vector3(myObject.transform.position.x,-5,myObject.transform.position.z);


}

if(myObject.transform.position.y>5){

myObject.transform.position= new Vector3(myObject.transform.position.x,5,myObject.transform.position.z);


}


}