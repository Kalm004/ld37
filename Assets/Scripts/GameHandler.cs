using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {
    private Dictionary<int, QuestionModel> questions = new Dictionary<int, QuestionModel>();
    private ProblemModel[] problems;
    private QuestionModel currentQuestion;
    private float timeToBalloon = 0.5f;

    public TextAsset textAsset;
    public Text questionText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    public Canvas canvas;

    public GameObject[] badBallons;
    public GameObject[] goodBallons;

    private GameObject[] currentBalloons;

    private float? timeToSelect = null;
    private float timeToChangeBalloon = 0;
    private int currentBalloon = 0;

    // Use this for initialization
    void Start () {
        GameData gameData = ObjectsFactory.getGameData(textAsset.text);
        problems = gameData.problems;
        foreach (QuestionModel question in gameData.questions)
        {
            questions.Add(question.id, question);
        }
        currentQuestion = questions[0];
        selectQuestion(currentQuestion);
    }
	
	// Update is called once per frame
	void Update () {
		if (timeToSelect != null && Time.time >= timeToSelect)
        {
            selectQuestion(currentQuestion);
            canvas.gameObject.SetActive(true);
            timeToSelect = null;
            foreach(GameObject balloon in currentBalloons) {
                balloon.SetActive(false);
            }
            timeToChangeBalloon = 0;
        } else
        {
            if (timeToChangeBalloon > 0)
            {
                if (Time.time > timeToChangeBalloon)
                {
                    timeToChangeBalloon = Time.time + timeToBalloon;
                    currentBalloons[currentBalloon].SetActive(false);
                    if (currentBalloon == 0)
                    {
                        currentBalloon = 1;
                    } else
                    {
                        currentBalloon = 0;
                    }
                    currentBalloons[currentBalloon].SetActive(true);
                }
            }
        }
	}

    private void selectQuestion(QuestionModel question)
    {
        questionText.text = question.text;
        int n = question.answers.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            AnswerModel temp = question.answers[n];
            question.answers[n] = question.answers[k];
            question.answers[k] = temp;
        }
        answer1Text.text = question.answers[0].text;
        answer2Text.text = question.answers[1].text;
        answer3Text.text = question.answers[2].text;
        answer4Text.text = question.answers[3].text;
    }

    public void answerSelected(int answerNumber)
    {
        AnswerModel answer = currentQuestion.answers[answerNumber - 1];
        timeToSelect = Time.time + answer.waitTime;
        currentQuestion = questions[answer.targetQuestionId];
        if (answer.waitTime > 2)
        {
            currentBalloons = badBallons;
        } else
        {
            currentBalloons = goodBallons;
        }
        waitingForProcess();
    }

    private void waitingForProcess()
    {
        canvas.gameObject.SetActive(false);
        timeToChangeBalloon = Time.time;
    }
}
