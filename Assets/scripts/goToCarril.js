#pragma strict

function Start () {
var carril= Random.Range(2,7);
this.transform.position=new Vector3 (carril,this.transform.position.y,this.transform.position.z);
}

function Update () {

}