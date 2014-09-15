using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO;
using System.Text;

public class IntermediateLevel : BaseGui {

	JSONNode question=null;
	JSONArray answers=null;
	static string nextLevel="Start";
	static string failLevel="Start";
	bool loadingLevel=false;

	enum QuestionStatus{correct,wrong,unanswered};
	QuestionStatus questionStatus=QuestionStatus.unanswered;

	public static void setNextLevel(string level){
		IntermediateLevel.nextLevel=level;
	}
	public static void setFailLevel(string level){
		IntermediateLevel.failLevel=level;
	}
	void Start () {
		loadingLevel=false;
		base.Start();
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
		base.OnGUI();
		Rect boxRect=new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f);
		if(loadingLevel==false){
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
			addButtons(dic,boxRect);
		} else if(questionStatus==QuestionStatus.correct ){

			addBOX("Respuesta correcta!!!\n¿Deseas compartir tu puntuacion en Facebook?");
			Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
			dic.Add("Si",delegate {
				FBUtil.score(((int)HUD.getPoints())+"",delegate {
					GotoLvl.changeLevel(true);
					
				});
			});
			dic.Add("No, llevame al siguiente nivel",delegate {
		
					//esta parte deveria cambiarse por una funcion donde asignemos el valor del sublvl en ves de mandar llamra una de maneras repetida
					if(PlayerPrefs.GetInt ("level")==1){//esto checa si es el lvl 1 para que solo tenga 1 sublvl
						
						
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						
						
					}
					if(PlayerPrefs.GetInt ("level")==2&&PlayerPrefs.GetInt ("sublevel")==1){//esto checa si es el lvl 1 para que solo tenga 1 sublvl
						
						
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						GotoLvl.changeSubLevel();
						
					}

				GotoLvl.changeSubLevel();
					loadingLevel=true;
					GotoLvl.changeLevel(true);
				
			});
			dic.Add("Repetir nivel",delegate {
				Debug.Log(nextLevel);
					GotoLvl.changeLevel(true);
				
			});
			addButtons(dic,boxRect);


		}else if(questionStatus==QuestionStatus.wrong){
			addBOX("La respuesta correcta era:\n "+question["good"]);
			Dictionary<string,ButtonDelegate> dic= new Dictionary<string,ButtonDelegate>();
			dic.Add("Repetir nivel",delegate {
				GotoLvl.changeLevel(false);
			});
			dic.Add("Menu principal",delegate {
				Application.LoadLevel("Start");				
			});
			addButtons(dic,boxRect);
		}

		}//end if loadinglevel
		else{


		GUI.Label(new Rect(Screen.width*0.5f, Screen.height*0.5f, Screen.width, Screen.height*0.13f), "Cargando...");


		}
	}
	private void addBOX(string title){
		GUI.Box(new Rect(Screen.width*.1f,Screen.height*.1f,Screen.width*.8f,Screen.height*.8f),title);
	}


	void Update () {

	}
}
