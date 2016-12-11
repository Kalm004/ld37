using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJellyfish : MonoBehaviour {


	public int increasing_x = 0;
	public int increasing_y = 0;
	public GameObject jellyFish;
	void Update () {
		jellyFish.transform.Translate (new Vector3 (increasing_x*10,increasing_y*10,0)* Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D other){
		switch(other.tag){
		case "bottomTrigger":
			increasing_y = 1;
			break;
		case "topTrigger":
			increasing_y = -1;
			break;
		case "leftTrigger":
			increasing_x = 1;
			break;
		case "rightTrigger":
			increasing_x = -1;
			break;
		}
	}
}
