#pragma strict

public var myTerrain: Terrain;
public var myTerrainLenght: int=1015;
public var myTerrainIncrement: int=100;
public var mySpawController: GameObject;
public var myLvlFinished: GameObject;
public var mySpawnStopper: GameObject;



private var sublvl:int;
function Start () {
	sublvl = GotoLvl.getSubLevel ();
	myTerrain.terrainData.size=new Vector3(8,8,(myTerrainLenght+(myTerrainIncrement*sublvl)));
	myLvlFinished.transform.position=Vector3(myLvlFinished.transform.position.x,myLvlFinished.transform.position.y,(myTerrainLenght+(myTerrainIncrement*sublvl)));
	mySpawnStopper.transform.position=Vector3(mySpawnStopper.transform.position.x,mySpawnStopper.transform.position.y,myLvlFinished.transform.position.z-50);
}

function Update () {

}