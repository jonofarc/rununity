using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GotoLvl : MonoBehaviour {

	//public int lvlNumber=0;
	public float timeToLoadNextLvlv=0;

	Texture2D loadingBackground = (Texture2D)Resources.Load("GUI/menu/sec_inicio_00000");

	void lvlFinished(){
		Invoke("llamadaAfuncionEstupidaPorqueUnityNoTieneDElegadosConDelay",timeToLoadNextLvlv);		
	}
	void llamadaAfuncionEstupidaPorqueUnityNoTieneDElegadosConDelay(){
		changeLevel ();		//changeLevelDirectly ();
	}
	public static int finalLevel=5;
	public static int subLvls=5;
	public static int currentsubLvls=0;
	public static void changeLevel(bool succes=true){
		//0==Estamos un nivel, 1 estamos en un menu,2 estamos en un video 
			

			string loadedLevelName=Application.loadedLevelName;
			if(loadedLevelName.Contains("LevelIntermediate") ){
				if(succes){
					loadLvl(2);
				}else{
					loadLvl(0);
				}
			}else if(loadedLevelName.Contains("Video")){
				int currentLevel = PlayerPrefs.GetInt ("level");
				currentLevel++;
				if (currentLevel == 0 || currentLevel>finalLevel)
					currentLevel = 1;
				PlayerPrefs.SetInt ("level", currentLevel);
				loadLvl(0);
			}else if(loadedLevelName=="Start"){
				loadLvl(0);
			}else{
				loadLvl(1);
			}

	}

	//0== un nivel, 1  en un menu,2  en un video 
	static void loadLvl(int tipoNivelIda){
		int currentLevel= PlayerPrefs.GetInt("level");
		if (currentLevel <= 0 || currentLevel>finalLevel )
			currentLevel = 1;
		string nextLevel = null;
		switch (tipoNivelIda) {
		case 0: nextLevel="Level"+currentLevel; break;
		case 1:nextLevel="LevelIntermediate";  break;
		case 2:nextLevel="VideoInicioLvl"+(currentLevel+1); break;
			default:nextLevel="Start";break;
		}	
	
		if (currentsubLvls == subLvls&&tipoNivelIda==2) {

			currentsubLvls=0;
			PlayerPrefs.SetInt ("subLvlv", currentsubLvls);
	


			Application.LoadLevel(nextLevel);


		

		}
		else if(tipoNivelIda==2){
			nextLevel="Level"+currentLevel;

			Application.LoadLevel(nextLevel);
		}else{

			Application.LoadLevel(nextLevel);
		}

		
		
	}


	
	public static void changeSubLevel(){

		currentsubLvls++;
		PlayerPrefs.SetInt ("subLvlv", currentsubLvls);

	}
	public static void setSubLevel(){
		
		currentsubLvls = PlayerPrefs.GetInt ("subLvlv");

		
	}
	public static int getSubLevel(){
		
		return currentsubLvls;
		
	}

}
