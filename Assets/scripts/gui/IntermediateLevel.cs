using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System.Text;

public class IntermediateLevel : MonoBehaviour {

	JSONNode question=null;
	JSONArray answers=null;
	static string nextLevel="Start";
	static string failLevel="Start";
	public static void setNextLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	public static void setFailLevel(string level){
		IntermediateLevel.nextLevel=level;
	}

	void Start () {
		TextAsset fileContents= Resources.Load("questions") as TextAsset;
		JSONNode json=JSON.Parse(fileContents.ToString());
		int quest= Random.Range(1,json.Count);
		question=json[quest];
		answers=question["bad"].AsArray;
		answers.Add(question["good"]);

		for (int i = answers.Count - 1; i > 0; i--) {
			int r = Random.Range(0,i);
			JSONNode tmp = answers[i];
			answers[i] = answers[r];
			answers[r] = tmp;
		}
		
		
		
	}
	void OnGUI(){
		GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f ),question["q"]);
		float buttonHeight=((Screen.height*.7f)/answers.Count)-5f;
		float buttonWidth=Screen.width*.7f;
		int count=1;
		foreach(JSONNode answer in answers){
			if(GUI.Button(new Rect(Screen.width*.15f,count*buttonHeight,buttonWidth,buttonHeight),answer)){
				if(!answer.Equals(question["good"]))
					Application.LoadLevel(nextLevel);
				else 
					Application.LoadLevel(failLevel);			
			}
			count++;
		}


	}


	// Update is called once per frame
	void Update () {
	
	}
}
