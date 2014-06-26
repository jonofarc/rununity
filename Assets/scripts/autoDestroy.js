#pragma strict
public var myPlayer: GameObject;

public var distanceTillDestroy: int;

function Start () {

}

function Update () {

if(myPlayer.transform.position.z>(this.transform.position.z+distanceTillDestroy)){
Destroy (this.gameObject);

}
/*
if(this.transform.position.y<-15){

this.transform.position= new Vector3(this.transform.position.x,-15,this.transform.position.z);


}

if(this.transform.position.y>25){

this.transform.position= new Vector3(this.transform.position.x,25,this.transform.position.z);


}

*/
}