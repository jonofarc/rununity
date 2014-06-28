#pragma strict
private var terrainHeight=0;

function Start () {

}

function Update () {

	if(this.transform.position.y<terrainHeight&&terrainHeight==3){
		this.transform.Translate(0,8*Time.deltaTime,0);
	}
	if(this.transform.position.y>terrainHeight&&terrainHeight==0){
		this.transform.Translate(0,-8*Time.deltaTime,0);
	}
	
	
}
function terrainAdjust(){
	if(terrainHeight==0){
		terrainHeight=3;
	}
	else{
		terrainHeight=0;
	}

	//this.transform.position= new Vector3(this.transform.position.x,terrainHeight,this.transform.position.z);
}