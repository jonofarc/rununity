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
	GUIStyle myStyle = null;
	bool correcto=false;
	bool faceCalled=false;
	public static void setNextLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	public static void setFailLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	bool conFace=false;
	void Start () {
		FBUtil.init(ref conFace);
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
		if(!correcto && conFace){
			myStyle = new GUIStyle(GUI.skin.box);
			myStyle.fontSize=20;
			GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f ),question["q"],myStyle);
			float buttonHeight=((Screen.height*.7f)/answers.Count)-10f;
			float buttonWidth=Screen.width*.7f;
			int count=1;

			myStyle = new GUIStyle(GUI.skin.button);
			myStyle.fontSize=20;
			foreach(JSONNode answer in answers){
				addButton(count*buttonHeight,buttonWidth,buttonHeight, answer);
				count++;
			}
		} else if(correcto ){
			FBUtil.score("100000",delegate {
				Application.LoadLevel(nextLevel);
			});
			correcto=false;
		}


	}
	private void addButton( float top, float width,float height, JSONNode answer  ){
		if(GUI.Button(new Rect(Screen.width*.15f,top,width,height),answer,myStyle )){
			if(answer.Equals(question["good"]))
				if(conFace)
					correcto=true;					
			else 
				Application.LoadLevel(failLevel);			
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
