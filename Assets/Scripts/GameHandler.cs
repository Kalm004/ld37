using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {
    private Dictionary<int, QuestionModel> questions = new Dictionary<int, QuestionModel>();
    private ProblemModel[] problems;
    private QuestionModel currentQuestion;
    private float timeToBalloon = 0.5f;
    private float currentProgress = 0;
    private float timeToExclamation = 1f;
    private float problemProbability = 0.2f;
    private int finaltQuestion = 999;
    private float timeToLose = 60;

    public TextAsset textAsset;
    public Text questionText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    public Canvas canvas;

    public Image image;

    public GameObject[] badBallons;
    public GameObject[] goodBallons;

    public GameObject exclamation;

    public Canvas winCanvas;

    public Canvas loseCanvas;

    public AudioSource discusionSound;

    public AudioSource heartBeat;

    private GameObject[] currentBalloons;

    private float? timeToSelect = null;
    private float timeToChangeBalloon = 0;
    private int currentBalloon = 0;

    private int currentProblem = 0;

    private int nextQuestionId = 0;

    private float timeToHideExclamation = 0;

    private bool finished = false;

    private float TimeToHeartBeat = 0;

    // Use this for initialization
    void Start () {
        discusionSound = GetComponent<AudioSource>();
        GameData gameData = ObjectsFactory.getGameData(textAsset.text);
        problems = gameData.problems;
        int n = problems.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            ProblemModel temp = problems[n];
            problems[n] = problems[k];
            problems[k] = temp;
        }
        foreach (QuestionModel question in gameData.questions)
        {
            questions.Add(question.id, question);
        }
        currentQuestion = questions[0];
        selectQuestion(currentQuestion);
    }
	
	// Update is called once per frame
	void Update () {
        if (!finished)
        {
            if (TimeToHeartBeat == 0 && Time.time > (timeToLose - 10))
            {
                heartBeat.Play();
            }
            if (Time.time > timeToLose)
            {
                loseCanvas.gameObject.SetActive(true);
                finished = true;
            }
            else
            {
                if (timeToHideExclamation > 0 && Time.time > timeToHideExclamation)
                {
                    exclamation.SetActive(false);
                }

                if (timeToSelect != null && Time.time >= timeToSelect)
                {
                    canvas.gameObject.SetActive(true);
                    timeToSelect = null;
                    foreach (GameObject balloon in currentBalloons)
                    {
                        balloon.SetActive(false);
                    }
                    timeToChangeBalloon = 0;

                    if (nextQuestionId == finaltQuestion)
                    {
                        winCanvas.gameObject.SetActive(true);
                        finished = true;
                    }
                    else if (Random.Range(0, 1f) < problemProbability)
                    {
                        exclamation.SetActive(true);
                        timeToHideExclamation = Time.time + timeToExclamation;
                        AnswerModel[] problemAnswers = new AnswerModel[problems[currentProblem].answers.Length];
                        int i = 0;
                        foreach (AnswerProblemModel apm in problems[currentProblem].answers)
                        {
                            problemAnswers[i] = new AnswerModel(apm.text, nextQuestionId, apm.effect);
                            i++;
                        }
                        currentQuestion = new QuestionModel(0, problems[currentProblem].text, problemAnswers);
                        selectQuestion(currentQuestion);
                        currentProblem++;
                        problemProbability = 0;
                    }
                    else
                    {
                        currentQuestion = questions[nextQuestionId];
                        selectQuestion(currentQuestion);
                        if (problemProbability == 0)
                        {
                            problemProbability = 0.2f;
                        }
                        else
                        {
                            problemProbability += 0.1f;
                        }
                    }
                }
                else
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
                            }
                            else
                            {
                                currentBalloon = 0;
                            }
                            currentBalloons[currentBalloon].SetActive(true);
                        }
                    } else
                    {
                        discusionSound.Stop();
                    }
                }
                image.fillAmount = currentProgress;
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
        nextQuestionId = answer.targetQuestionId;
        timeToSelect = Time.time + (answer.waitTime <= 4 ? answer.waitTime : 4);
        if (answer.waitTime > 2)
        {
            currentBalloons = badBallons;
            discusionSound.Play();
        } else
        {
            currentBalloons = goodBallons;
        }
        waitingForProcess();
        if (problemProbability >= 0)
        {
            currentProgress += 0.1f;
        }
    }

    private void waitingForProcess()
    {
        canvas.gameObject.SetActive(false);
        timeToChangeBalloon = Time.time;
    }
}
