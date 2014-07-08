using UnityEngine;
using System.Collections;

public class stopSpanC : MonoBehaviour {
	 public GameObject mySpawnController;
	 public GameObject myLvlFinished;
	public Terrain myTerrain;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
	
		int x =(int)HUD.points;
		int terrainSize =(int) myTerrain.terrainData.size.z-100;
 
		Debug.Log (x);
		if (x>(2048*terrainSize/17)){

			x=3;
		}
		else if (x>(1024*terrainSize/17)){
			x=2;
		}
		else{
			x=1;
		}
		myLvlFinished.renderer.material.mainTextureScale = new Vector2 (x,1);
		mySpawnController.SetActive(false);
		Destroy(this.gameObject);
	
	}

}
