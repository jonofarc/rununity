#pragma strict

public var myPlayer: GameObject;
public var BadSpawneable : Transform;
public var GoodSpawneable : Transform;
public var mainCamera: GameObject;
public var distanceForGoodOrBad: int;
public var spawnDistance: int;


private var passedTime : float;
private var spawnGoodTrue: int;
private var carril: int;
private var distanseToNextGoodSpawn: float;




function Start () {
passedTime= myPlayer.transform.position.z+distanceForGoodOrBad;
spawnGoodTrue=0;
}

function Update () {
 
	if(myPlayer.transform.position.z>passedTime){
	spawnGoodTrue=0;
	distanseToNextGoodSpawn=0;
	mainCamera.SendMessage("setPoints");
	
	var GoodOrBad = Random.Range(0,2);
		if(GoodOrBad==0){
			BadSpawn();
			//GoodSpawn();
		
		}
		if(GoodOrBad==1){
	
			//GoodSpawn();
			spawnGoodTrue=1;
		
		}

		passedTime= myPlayer.transform.position.z+distanceForGoodOrBad;
		//Invoke( "success", 3.0 );
		
	}


	if((spawnGoodTrue==1)&&(myPlayer.transform.position.z>(passedTime-distanceForGoodOrBad+distanseToNextGoodSpawn))){
	Debug.Log("entre a good");
		GoodSpawn();
		distanseToNextGoodSpawn=distanseToNextGoodSpawn+2.5;
	}



}

function BadSpawn(){

	var tipoEnemigo= Random.Range(1,7);

	if(tipoEnemigo==1){
		carril = 2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	//	Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+50)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==2){
		carril = 2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==3){
		carril = Random.Range(1,3)*2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==4){
		carril = Random.Range(1,4)*2;
		Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril,2.5,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	}
	if(tipoEnemigo==5){
		carril = 1;
	//	Instantiate (BadSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,2.5,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+4,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	}
		if(tipoEnemigo==6){
		carril = Random.Range(1,3)*2;
		Instantiate (BadSpawneable, new Vector3(carril,2.5,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
		Instantiate (BadSpawneable, new Vector3(carril+2,0.1,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	//	Instantiate (BadSpawneable, new Vector3(carril+4,2.5,(myPlayer.transform.position.z+spawnDistance)), BadSpawneable.transform.rotation);
	}

}
function GoodSpawn(){
	if(distanseToNextGoodSpawn<1){
		carril = Random.Range(1,4)*2;
	}


	Instantiate (GoodSpawneable, new Vector3(carril,0.1,(myPlayer.transform.position.z+spawnDistance)), GoodSpawneable.transform.rotation);

	

}