using UnityEngine;
using System.Collections;

public class SwipeTest : MonoBehaviour {

Vector2 StartPos;
int SwipeID = -1;
int carril=4;
float minMovement = 10.0f;
public GameObject player;

// Use this for initialization
void Start ()
{

}
// Update is called once per frame
void Update ()
{
		player.transform.position=new Vector3(carril,(player.transform.position.y+0.0f),player.transform.position.z);

		if (Time.timeScale == 0)
			return;
		if (Input.GetKey("t")) {
		carril=carril-2;
		if (carril<2) {
			carril=2;
			}
		player.transform.position=new Vector3(carril,(player.transform.position.y+0.0f),player.transform.position.z);
			
		}
		if (Input.GetKey("y")) {
			
		carril=carril+2;
		if (carril>6) {
			carril=6;
			}
			
		player.transform.position=new Vector3(carril,(player.transform.position.y+0.0f),player.transform.position.z);
		
		}
		
		if (Input.GetKey("u")) {
			
			this.SendMessage("swipeup");
		}
	
		if (Input.GetKey("j")) {
			
			this.SendMessage("deadAnimation");
		}
		
	
    foreach (var T in Input.touches) {
       var P = T.position;
       if (T.phase == TouchPhase.Began && SwipeID == -1) {
         SwipeID = T.fingerId;
         StartPos = P;
       } else if (T.fingerId == SwipeID) {
         var delta = P - StartPos;
         if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement) {
          SwipeID = -1;
          if (Mathf.Abs (delta.x) > Mathf.Abs (delta.y)) {
              if (delta.x > 0) {
 
                Debug.Log ("Swipe Right Found");							
				carril=carril+2;
				if (carril>6) {
					carril=6;
				}
			
				player.transform.position=new Vector3(carril,player.transform.position.y,player.transform.position.z);
		
							
              } else {
 
                Debug.Log ("Swipe Left Found");						
				carril=carril-2;
				if (carril<2) {
					carril=2;
				}
				player.transform.position=new Vector3(carril,player.transform.position.y,player.transform.position.z);
			
							
							
							
              }
          } 
          else {
              if (delta.y > 0) {
 
                Debug.Log ("Swipe Up Found");
				this.SendMessage("swipeup");
							SwipeID = -1;
							
              } else {
 
                Debug.Log ("Swipe Down Found");
				this.SendMessage("swipeup");
							SwipeID = -1;
							
              }
          }
         } else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
          SwipeID = -1;
       } 
    }
}   
}