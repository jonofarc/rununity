#pragma strict

public var secondsToWait: float;
private var newTick: float;


function Start () {
secondsToWait=1f;
newTick=Time.time+secondsToWait;
}

function Update () {


if(newTick<Time.time){
Debug.Log("entre");

	if((this.transform.position.x>0)&&(this.transform.position.x<3)){

		this.transform.position=new Vector3 (2,this.transform.position.y,this.transform.position.z);

	}




newTick=Time.time+secondsToWait;
}//end of if(newTick>Time.time)



}