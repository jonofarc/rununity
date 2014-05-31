using UnityEngine;
using System.Collections;



public class gotoLvl : MonoBehaviour {

	public int lvlNumber=0;
	public float timeToLoadNextLvlv=0;
	private string myNextLvl;

	// Use this for initialization
	void Start () {
	
		if(lvlNumber==1){
			myNextLvl="Start";
		}
		if(lvlNumber==3){
			myNextLvl="LevelIntermediate";
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void lvlFinished(){
		

		
		Invoke("loadLvl",timeToLoadNextLvlv);
		
	}

	void loadLvl(){
		
		IntermediateLevel.setNextLevel("Start");
		IntermediateLevel.setFailLevel("Level1");
		
		Application.LoadLevel(myNextLvl.ToString());
		
		
	}



}
