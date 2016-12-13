using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsController : MonoBehaviour {
    public GameHandler gameHandler;
	public AudioSource clickSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onAnswer1Click()
    {
        gameHandler.answerSelected(1);
		clickSound.Play ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void onAnswer2Click()
    {
        gameHandler.answerSelected(2);
		clickSound.Play ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void onAnswer3Click()
    {
        gameHandler.answerSelected(3);
		clickSound.Play ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void onAnswer4Click()
    {
        gameHandler.answerSelected(4);
		clickSound.Play ();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
