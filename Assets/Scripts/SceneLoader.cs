using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
    public GameObject panel;

	public void loadGameScene()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        panel.SetActive(true);
	}
	public void loadCreditScene()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene ("CreditScene");
	}
	public void exit()
	{
		Application.Quit();
	}
	public void loadMainMenuScene()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene ("MainMenuScene");
	}

    public void normal()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameHandler.difficulty = Difficulty.normal;
        SceneManager.LoadScene("Scene1");
    }

    public void dificil()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameHandler.difficulty = Difficulty.hard;
        SceneManager.LoadScene("Scene1");
    }
}
