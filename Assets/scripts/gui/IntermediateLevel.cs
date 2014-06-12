using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO;
using System.Text;

public class IntermediateLevel : MonoBehaviour {

	JSONNode question=null;
	JSONArray answers=null;
	static string nextLevel="Start";
	static string failLevel="Start";

	enum QuestionStatus{correct,wrong,unanswered};
	QuestionStatus questionStatus=QuestionStatus.unanswered;

	public static void setNextLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	public static void setFailLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	void Start () {
		FBUtil.init();
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
		if(questionStatus==QuestionStatus.unanswered ){

			addBOX(question["q"]);

			Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
			foreach(JSONNode answer in answers){
				dic.Add(answer,delegate(string text) {
					if(text.Equals(question["good"]))
						questionStatus=QuestionStatus.correct;					
					else 
						questionStatus=QuestionStatus.wrong;
				});
			}
			addButtons(dic);

			/*float buttonHeight=((Screen.height*.7f)/answers.Count)-10f;
			float buttonWidth=Screen.width*.7f;
			int count=1;

			myStyle = new GUIStyle(GUI.skin.button);
			myStyle.fontSize=20;
			foreach(JSONNode answer in answers){
				addButton(count*buttonHeight,buttonWidth,buttonHeight, answer);
				count++;
			}*/
		} else if(questionStatus==QuestionStatus.correct ){

			addBOX("Respuesta correcta!!!\n¿Deseas compartir tu puntuacion en Facebook?");
			Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
			dic.Add("Si",delegate {
				FBUtil.score(((int)HUD.getPoints())+"",delegate {
					Application.LoadLevel(nextLevel);
				});
			});
			dic.Add("No, llevame al siguiente nivel",delegate {
					Application.LoadLevel(nextLevel);
				
			});
			addButtons(dic);


		}else if(questionStatus==QuestionStatus.wrong){
			addBOX("La respuesta correcta era:\n "+question["good"]);
			Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
			dic.Add("Repetir nivel",delegate {
				Application.LoadLevel(failLevel);
			});
			dic.Add("Menu principal",delegate {
				Application.LoadLevel("Start");				
			});
			addButtons(dic);
		}


	}
	private void addBOX(string title){
		
		GUI.skin.box.fontSize=16;
		GUI.skin.box.wordWrap = true;
		GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f),title);
	}
	private delegate void ButtonDelegate (string text);

	private void addButtons(Dictionary<string,ButtonDelegate> data){
		GUI.skin.button.fontSize=16;
		GUI.skin.button.wordWrap = true;
		float buttonHeight=((Screen.height*.75f)/data.Count)-(10f*data.Count);
		float buttonWidth=Screen.width*.7f;
		int buttonNumber=0;
		foreach (KeyValuePair<string, ButtonDelegate> entry in data){
			if(GUI.Button(new Rect(Screen.width*.15f,(Screen.height*.2f)+((buttonHeight+5f)*buttonNumber)+5f,buttonWidth,buttonHeight),entry.Key)){
				entry.Value(entry.Key);
			}
			buttonNumber=buttonNumber+1;
		}
	}

	void Update () {

	}
}
