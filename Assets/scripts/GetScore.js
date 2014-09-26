#pragma strict

function Start () {

/*

		Debug.Log(PlayerPrefs.GetInt("puntajeLvl1subLevel0"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl2subLevel0"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl2subLevel1"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl3subLevel0"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl3subLevel1"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl4subLevel0"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl4subLevel1"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl5subLevel0"));
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl5subLevel1"));
	*/
	







		Debug.Log("para el lvl 1 y el sublvl 0 el puntaje es de");
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl1subLevel0"));


		for( var i = 2; i < 6; i++){

			for( var j = 0; j < GotoLvl.subLvls; j++){

				Debug.Log("para el lvl "+i+" y el sublvl "+j+" el puntaje es de");

				Debug.Log(PlayerPrefs.GetInt("puntajeLvl"+i+"subLevel"+j));
			}

		}



}

function Update () {

}