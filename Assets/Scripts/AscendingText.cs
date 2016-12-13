using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AscendingText : MonoBehaviour {

	public Transform creditText;
	public GameObject gameObject;
    public Text text;
    public Text buttonText;
	void Start () {
        text.text = GameHandler.texts.getCreditsContent();
        buttonText.text = GameHandler.texts.getCreditsMainMenu();
    }
	
	// Update is called once per frame
	void Update () {
		if(creditText != null && creditText.position.y < 0 ){
			creditText.Translate (new Vector3 (0,10,0)* Time.deltaTime);
		}
		if (creditText.position.y >= 0){
			gameObject.SetActive (true);
		}
		if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
			SceneManager.LoadScene ("MainMenuScene");
	}
}
