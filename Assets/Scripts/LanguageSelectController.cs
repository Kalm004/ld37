using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageSelectController : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSpanishClick()
    {
        GameHandler.language = Languages.SPANISH;
        GameHandler.texts = new SpanishTexts();
        SceneManager.LoadScene("MainMenuScene");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void onEnglishClick()
    {
        GameHandler.language = Languages.ENGLISH;
        GameHandler.texts = new EnglishTexts();
        SceneManager.LoadScene("MainMenuScene");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
