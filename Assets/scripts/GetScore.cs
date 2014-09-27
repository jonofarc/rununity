using UnityEngine;
using System.Collections;

public class GetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {




	




	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void GetMyScore(){

		
		
		for(int i = 2; i <= GotoLvl.finalLevel; i++){
			
			for(int j = 0; j < GotoLvl.subLvls; j++){
				
				Debug.Log("para el lvl "+i+" y el sublvl "+j+" el puntaje es de");
				
				Debug.Log(PlayerPrefs.GetInt("puntajeLvl"+i+"subLevel"+j));
			}
			
		}


	}
	public static void ResetMyScore(){
		

		
		
		for(int i = 1; i <= GotoLvl.finalLevel; i++){
			
			for(int j = 0; j < GotoLvl.subLvls; j++){
				

				
				PlayerPrefs.SetInt("puntajeLvl"+i+"subLevel"+j,0);


			}
			
		}
		
		
	}
}
