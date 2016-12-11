using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {
    private string IntroText = "Bienvenidos a EscapeJam. \nEstais encerrados en esta habitación hasta que termineis vuestro juego... si la habitación no termina primero con vosotros.";

    private const float timeShowFinishScreen = 5;

    private const int plataformaFinalId = 995;
    private const int fpsFinalId = 996;
    private const int mmoFinalId = 997;
    private const int aventuraGraficaFinalId = 998;

    private Dictionary<int, QuestionModel> questions = new Dictionary<int, QuestionModel>();
    private ProblemModel[] problems;
    private QuestionModel currentQuestion;
    private float timeToBalloon = 0.5f;
    private float currentProgress = 0;
    private float timeToExclamation = 1f;
    private float problemProbability = 0.2f;
    private float timeToLose = 120;
    private float shakeDuration = 0.1f;

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

    public GameObject answerButtons;

	public AudioSource typingSound;

	public GameObject player1Happy;
	public GameObject player1Angry;
	public GameObject player2Happy;
	public GameObject player2Angry;

    public GameObject imagenFinalAventura;
    public GameObject imagenFinalFPS;
    public GameObject imagenFinalMMO;
    public GameObject imagenFinalPlataforma;

    private GameObject[] currentBalloons;

    private float? timeToSelect = null;
    private float timeToChangeBalloon = 0;
    private int currentBalloon = 0;

    private int currentProblem = 0;

    private int nextQuestionId = 0;

    private float timeToHideExclamation = 0;

    public bool finished = true;

    private float TimeToHeartBeat = 0;

    private float hideIntroTime;

    private float shakeAmt = 0;

    private float timeToStopShake = 0;

    private Vector3 oldPosition;

    private float timeToHideFinishScreen = 0;

    // Use this for initialization
    void Start () {
        oldPosition = transform.position;
        finished = true;
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
        hideIntroTime = Time.time + 5;
        questionText.text = IntroText;
        answerButtons.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToStopShake > 0 && Time.time > timeToStopShake)
        {
            shakeAmt = 0;
            timeToStopShake = 0;
            transform.position = oldPosition;
        }

        CameraShake();
        if (hideIntroTime > 0)
        {
            if (Time.time > hideIntroTime)
            {
                hideIntroTime = 0;
                currentQuestion = questions[0];
                selectQuestion(currentQuestion);
                answerButtons.SetActive(true);
                finished = false;
            }
            return;
        }
        if (!finished)
        {
            if ((TimeToHeartBeat == 0 && Time.time > (timeToLose - 20)) || (TimeToHeartBeat > 0 && Time.time > TimeToHeartBeat))
            {
                heartBeat.Play();
                oldPosition = transform.position;
                shakeAmt = 0.1f;
                timeToStopShake = Time.time + shakeDuration;
                TimeToHeartBeat = Time.time + 1;
            }
            if (Time.time > timeToLose)
            {
                canvas.gameObject.SetActive(false);
                loseCanvas.gameObject.SetActive(true);
                timeToHideFinishScreen = Time.time + timeShowFinishScreen;
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

                    if (nextQuestionId >= plataformaFinalId)
                    {
                        canvas.gameObject.SetActive(false);
                        winCanvas.gameObject.SetActive(true);
                        switch (nextQuestionId)
                        {
                            case plataformaFinalId:
                                imagenFinalPlataforma.SetActive(true);
                                break;
                            case aventuraGraficaFinalId:
                                imagenFinalAventura.SetActive(true);
                                break;
                            case fpsFinalId:
                                imagenFinalFPS.SetActive(true);
                                break;
                            case mmoFinalId:
                                imagenFinalMMO.SetActive(true);
                                break;
                            default:
                                break;
                        }
                        timeToHideFinishScreen = Time.time + timeShowFinishScreen;
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
						typingSound.Stop ();
						player1Happy.SetActive (true);
						player1Angry.SetActive (false);
						player2Happy.SetActive (true);
						player2Angry.SetActive (false);
                    }
                }
                image.fillAmount = currentProgress;
            }
        } else
        {
            if (Time.time > timeToHideFinishScreen)
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            transform.position = pp;
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
			player1Happy.SetActive (false);
			player1Angry.SetActive (true);
			player2Happy.SetActive (false);
			player2Angry.SetActive (true);
        } else
        {
            currentBalloons = goodBallons;
			typingSound.Play();
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
