using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void loadGameScene()
	{
		SceneManager.LoadScene ("Scene1");
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
}
