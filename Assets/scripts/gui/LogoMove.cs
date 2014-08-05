using UnityEngine;
using System.Collections;

public class LogoMove : MonoBehaviour {

	public GUITexture myGUITexture;
	// Use this for initialization
	void Start () {
		myGUITexture.pixelInset = new Rect((-302.1f), (-128f), 500f, 500f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}
}
