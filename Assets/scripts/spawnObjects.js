#pragma strict

public var myPlayer: GameObject;
public var BadSpawneable : Transform;
public var GoodSpawneable : Transform;
var passedTime : float;



function Start () {
passedTime= myPlayer.transform.position.z+10;
}

function Update () {

	if(myPlayer.transform.position.z>passedTime){
	
	var GoodOrBad = Random.Range(0,2);
		if(GoodOrBad==0){
			BadSpawn();
		
		}
		if(GoodOrBad==1){
			GoodSpawn();
		
		}

		passedTime= myPlayer.transform.position.z+10;
		//Invoke( "success", 3.0 );
		
	}




}

function BadSpawn(){
var carril: int;
	var tipoEnemigo= Random.Range(1,7);

	if(tipoEnemigo==1){
		carril = 2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	//	Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==2){
		carril = 2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==3){
		carril = Random.Range(1,3)*2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==4){
		carril = Random.Range(1,4)*2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril,2.5,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==5){
		carril = 1;
	//	Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,2.5,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
		if(tipoEnemigo==6){
		carril = Random.Range(1,3)*2;
		Instantiate (BadSpawneable, new Vector3(carril,2.5,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	//	Instantiate (BadSpawneable, new Vector3(carril+4,2.5,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}

}
function GoodSpawn(){
	var carril = Random.Range(1,4)*2;
	Instantiate (GoodSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), GoodSpawneable.transform.rotation);
	//Instantiate (GoodSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+52.5)), GoodSpawneable.transform.rotation);
	//Instantiate (GoodSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+55)), GoodSpawneable.transform.rotation);
	//Instantiate (GoodSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+57.5)), GoodSpawneable.transform.rotation);



}