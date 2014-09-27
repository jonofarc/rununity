using UnityEngine;
using System.Collections;

public class DisplayScores : MonoBehaviour {


	private string myText;
	private int myFinalScore=0;
	// Use this for initialization
	void Start () {

		myText = myText+ "Nivel " + "1" + " Subnivel " + "1" + " : " + PlayerPrefs.GetInt ("puntajeLvl1subLevel0")+ " Puntos \n";

		myFinalScore = myFinalScore+PlayerPrefs.GetInt ("puntajeLvl1subLevel1");

		for (int i = 2; i <= GotoLvl.finalLevel; i++) {
			
						for (int j = 0; j < GotoLvl.subLvls; j++) {
				
								

							myText = myText+ "Nivel " + i + " Subnivel " + (j+1) + " : " + PlayerPrefs.GetInt ("puntajeLvl" + i + "subLevel" + j)+" Puntos \n";
							myFinalScore = myFinalScore+PlayerPrefs.GetInt ("puntajeLvl" + i + "subLevel" + j);
						}// end for j
				}// end for i

		myText = myText+"\n\nEl puntaje Final del juego es:\n         "+myFinalScore.ToString();
		TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));

		t.text= myText;
	}//end start
	
	// Update is called once per frame
	void Update () {
	
	}
}
