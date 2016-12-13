using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Text playText;
    public Text creditsText;
    public Text exitText;
    public Text normalText;
    public Text hardText;

    // Use this for initialization
    void Start () {
        playText.text = GameHandler.texts.getMainMenuPlay();
        creditsText.text = GameHandler.texts.getMainMenuCredits();
        exitText.text = GameHandler.texts.getMainMenuExit();
        normalText.text = GameHandler.texts.getNormal();
        hardText.text = GameHandler.texts.getHard();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
