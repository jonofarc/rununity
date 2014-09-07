#pragma strict
var otherSkybox : Material[];  // assign via inspector

function Start () {

RenderSettings.skybox = otherSkybox[PlayerPrefs.GetInt("sublevel")];


}

function Update () {

}

 

