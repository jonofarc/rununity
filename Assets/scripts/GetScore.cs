using UnityEngine;
using System.Collections;

public class GetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {

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


		/*
		for(var i = 1; i < 6; i++){
			
			for(var j = 0; j < GotoLvl.subLvls; j++){
				//Debug.Log("para el lvl "+i+" y el sublvl "+j+" Asignando puntaje");
				PlayerPrefs.SetInt("puntajeLvl"+i+"subLevel"+j,j*i+j+i);
			}
			
		}

		*/

	




	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void GetMyScore(){

		Debug.Log("para el lvl 1 y el sublvl 0 el puntaje es de");
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl1subLevel0"));
		
		
		for(int i = 2; i < 6; i++){
			
			for(int j = 0; j < GotoLvl.subLvls; j++){
				
				Debug.Log("para el lvl "+i+" y el sublvl "+j+" el puntaje es de");
				
				Debug.Log(PlayerPrefs.GetInt("puntajeLvl"+i+"subLevel"+j));
			}
			
		}


	}
	public static void ResetMyScore(){
		
		Debug.Log("para el lvl 1 y el sublvl 0 el puntaje es de");
		Debug.Log(PlayerPrefs.GetInt("puntajeLvl1subLevel0"));
		
		
		for(int i = 2; i < 6; i++){
			
			for(int j = 0; j < GotoLvl.subLvls; j++){
				

				
				PlayerPrefs.SetInt("puntajeLvl"+i+"subLevel"+j,0);
			}
			
		}
		
		
	}
}
