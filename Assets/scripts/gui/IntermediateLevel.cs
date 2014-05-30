using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System.Text;

public class IntermediateLevel : MonoBehaviour {

	JSONNode question=null;
	JSONArray answers=null;
	void Start () {
		string fileContents="";
		string line="";		
		StreamReader theReader = new StreamReader(Application.dataPath + "/questions.txt");			
		using (theReader){
			while (line != null){
				line = theReader.ReadLine();
				fileContents+=line;

			}
			theReader.Close();
		}		

		JSONNode json=JSON.Parse(fileContents);
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
			if(GUI.Button(new Rect(Screen.width*.15f,count*buttonHeight,buttonWidth+5f,buttonHeight),answer)){
				if(answer.Equals(question["good"]))
					print ("la buena");
			////////////////aqui mando llamar el siguiente lvl al acertar a la pregunta////
				this.SendMessage("lvlFinished");

			}
			count++;
		}


	}


	// Update is called once per frame
	void Update () {
	
	}
}
