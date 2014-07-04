using UnityEngine;
using System.Collections;

public class nextLvlAssign : MonoBehaviour {

	public string myNextLvl="Start";
	// Use this for initialization
	void Start () {
		
		IntermediateLevel.setNextLevel(myNextLvl.ToString());
		IntermediateLevel.setFailLevel(Application.loadedLevelName);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
