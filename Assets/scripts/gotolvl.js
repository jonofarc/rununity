#pragma strict
public var lvlNumber: int;
public var timeToLoadNextLvlv: float;
private var myNextLvl;


function Start () {
if(lvlNumber==1){
myNextLvl="Start";
}
if(lvlNumber==3){
myNextLvl="LevelIntermediate";
}



}

function Update () {

}

function lvlFinished(){



Invoke("loadLvl",timeToLoadNextLvlv);

}

function loadLvl(){

Application.LoadLevel(myNextLvl.ToString());


}