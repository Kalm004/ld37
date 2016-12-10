using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsController : MonoBehaviour {
    public GameHandler gameHandler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onAnswer1Click()
    {
        gameHandler.answerSelected(1);
    }

    public void onAnswer2Click()
    {
        gameHandler.answerSelected(2);
    }

    public void onAnswer3Click()
    {
        gameHandler.answerSelected(3);
    }

    public void onAnswer4Click()
    {
        gameHandler.answerSelected(4);
    }
}
