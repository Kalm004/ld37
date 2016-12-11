using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
    public GameObject panel;

	public void loadGameScene()
	{
        panel.SetActive(true);
	}
	public void loadCreditScene()
	{
		SceneManager.LoadScene ("CreditScene");
	}
	public void exit()
	{
		Application.Quit();
	}
	public void loadMainMenuScene()
	{
		SceneManager.LoadScene ("MainMenuScene");
	}

    public void normal()
    {
        GameHandler.difficulty = Difficulty.normal;
        SceneManager.LoadScene("Scene1");
    }

    public void dificil()
    {
        GameHandler.difficulty = Difficulty.hard;
        SceneManager.LoadScene("Scene1");
    }
}
