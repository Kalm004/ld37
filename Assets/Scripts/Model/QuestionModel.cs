using System;

[Serializable]
public class QuestionModel {
    public int id;
    public string text;
    public AnswerModel[] answers;

    public QuestionModel(int id, string text, AnswerModel[] answers)
    {
        this.id = id;
        this.text = text;
        this.answers = answers;
    }
}
