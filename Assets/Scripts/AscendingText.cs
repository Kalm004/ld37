using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AscendingText : MonoBehaviour {

	public Transform creditText;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(creditText != null && creditText.position.y < 0 ){
			creditText.Translate (new Vector3 (0,10,0)* Time.deltaTime);
		}
		if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
			SceneManager.LoadScene ("MainMenuScene");
	}
}
