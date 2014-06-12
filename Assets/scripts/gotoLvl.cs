using UnityEngine;
using System.Collections;



public class gotoLvl : MonoBehaviour {

	public int lvlNumber=0;
	public float timeToLoadNextLvlv=0;
	private string myNextLvl;

	// Use this for initialization
	void Start () {
	
		if(lvlNumber==1){
			myNextLvl="VideoIntro";
		}
		if(lvlNumber==2){
			myNextLvl="Level1";
		}
		if(lvlNumber==3){
			myNextLvl="LevelIntermediate";
		}
		if(lvlNumber==4){
			myNextLvl="Level2";
		}
		if(lvlNumber==5){
			myNextLvl="Level3";
		}
		if(lvlNumber==6){
			myNextLvl="Start";
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void lvlFinished(){
		

		
		Invoke("loadLvl",timeToLoadNextLvlv);
		
	}

	void loadLvl(){
		
		IntermediateLevel.setNextLevel(myNextLvl.ToString());
		IntermediateLevel.setFailLevel(Application.loadedLevelName);
		
		Application.LoadLevel("LevelIntermediate");
		
		
	}



}
