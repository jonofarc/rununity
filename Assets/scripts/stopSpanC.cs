using UnityEngine;
using System.Collections;

public class stopSpanC : MonoBehaviour {
	 public GameObject mySpawnController;
	 public GameObject myLvlFinished;
	public Terrain myTerrain;


	// Use this for initialization
	void Start () {
		int x =(int)HUD.points;
		int terrainSize =(int) myTerrain.terrainData.size.z-50;
		Debug.Log (2048*terrainSize/20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
	
		int x =(int)HUD.points;
		int terrainSize =(int) myTerrain.terrainData.size.z-50;
 

		if (x>(2048*terrainSize/20)){

			x=3;
		}
		else if (x>(1024*terrainSize/20)){
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
