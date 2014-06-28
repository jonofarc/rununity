#pragma strict

public var myPlayer: GameObject;
public var BadSpawneable : GameObject;
public var GoodSpawneable : GameObject;
public var mainCamera: GameObject;
public var BadChances: int;
public var GoodChances: int;
public var BadSpawneableHeight: int;
private var goodSpawnHeight;
public var distanceForGoodOrBad: int;
public var spawnDistance: int;
public var backgroundObjectsOn: boolean; 
public var backgroundChances: int; //0 es igual a que siempre aparesca entre mas alto el numero menos posibilidaddes de salir
public var backgroundObjects : GameObject[];; 

private var passedTime : float;
private var spawnGoodTrue: int;
private var carril: int;
private var distanseToNextGoodSpawn: float;
private var clone: GameObject;




function Start () {
passedTime= myPlayer.transform.position.z+distanceForGoodOrBad;
spawnGoodTrue=0;

}

function Update () {
 
	if(myPlayer.transform.position.z>passedTime){
	spawnGoodTrue=0;
	distanseToNextGoodSpawn=0;
	mainCamera.SendMessage("setPoints");
	
	var GoodOrBad = Random.Range(0,(GoodChances+BadChances));
	var doBackgroundObjects = Random.Range(0,backgroundChances+1);
	//Debug.Log(doBackgroundObjects+"doBackgroundObjects");
	
		if(GoodOrBad<BadChances){
			BadSpawn();
			//GoodSpawn();
		
		}
	//	if(GoodOrBad>=GoodChances+BadChances){
		else{

			//GoodSpawn();
			spawnGoodTrue=1;
		
		}
		
		if(doBackgroundObjects==backgroundChances&&backgroundObjectsOn==true){
	
			backgroundObjectSpawn(0);
			
		
		}

		passedTime= myPlayer.transform.position.z+distanceForGoodOrBad;
		//Invoke( "success", 3.0 );
		
	}


	if((spawnGoodTrue==1)&&(myPlayer.transform.position.z>(passedTime-distanceForGoodOrBad+distanseToNextGoodSpawn))){

		GoodSpawn();
		distanseToNextGoodSpawn=distanseToNextGoodSpawn+5;
	}



}

function BadSpawn(){


	var tipoEnemigo= Random.Range(1,12);

	if(tipoEnemigo==1){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+2,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==2){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+2,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==3){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+2,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==4){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+2,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==4){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==5){
		carril = 2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril+4,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}
	if(tipoEnemigo==6||tipoEnemigo==7){
		carril = Random.Range(1,4)*2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);

	}
	if(tipoEnemigo==8||tipoEnemigo==9){
		carril = Random.Range(1,4)*2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);

	}
	if(tipoEnemigo==10||tipoEnemigo==11){
		carril = Random.Range(1,4)*2;
		clone=Instantiate (BadSpawneable, new Vector3(carril,0.1+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
		clone=Instantiate (BadSpawneable, new Vector3(carril,2.5+BadSpawneableHeight,(myPlayer.transform.position.z+spawnDistance)), Quaternion.Euler(0,180,0));
		clone.SetActive(true);
	}


}
function GoodSpawn(){
	if(distanseToNextGoodSpawn<1){
		carril = Random.Range(1,4)*2;
		
		goodSpawnHeight = Random.Range(1,3);
		if(goodSpawnHeight==2){
			goodSpawnHeight=3.5;
			
		}
		else{
			goodSpawnHeight=0.5;
		}
		
		
	}

	clone=Instantiate (GoodSpawneable, new Vector3(carril,goodSpawnHeight,(myPlayer.transform.position.z+spawnDistance)), GoodSpawneable.transform.rotation);
	clone.SetActive(true);
	

}

function backgroundObjectSpawn(object:int){

var spawny: int;
	carril = Random.Range(0,2);
	if(carril==0){
		carril=15;
	}
	else{
		carril=-10;
	}
	if(object==0){
		spawny=10;
	}





	clone=Instantiate (backgroundObjects[object], new Vector3(carril,spawny,(myPlayer.transform.position.z+200)),  Quaternion.Euler(0,0,0));
		clone.SetActive(true);



}