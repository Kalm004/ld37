using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Text playText;
    public Text creditsText;
    public Text exitText;

    // Use this for initialization
    void Start () {
        playText.text = GameHandler.texts.getMainMenuPlay();
        creditsText.text = GameHandler.texts.getMainMenuCredits();
        exitText.text = GameHandler.texts.getMainMenuExit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
