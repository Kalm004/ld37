using System;
[Serializable]
public class AnswerModel {
    public string text;
    public int targetQuestionId;
    public float waitTime;

    public AnswerModel(string text, int targetQuestionId, float waitTime)
    {
        this.text = text;
        this.targetQuestionId = targetQuestionId;
        this.waitTime = waitTime;
    }
}
