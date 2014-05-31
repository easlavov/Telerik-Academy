using System;

public class CSharpExam : Exam
{
    private const int MIN_SCORE = 0;
    private const int MAX_SCORE = 100;
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                string exceptionMessage = string.Format("Score must be at least {0}!", MIN_SCORE);
                throw new ArgumentOutOfRangeException(exceptionMessage);
            }

            if (value > 100)
            {
                string exceptionMessage = string.Format("Score must be {0} or smaller.", MAX_SCORE);
                throw new ArgumentOutOfRangeException(exceptionMessage);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        string comment = "Exam results calculated by score.";
        var examResult = new ExamResult(
                             this.Score, 
                             MIN_SCORE, 
                             MAX_SCORE, 
                             comment);
        return examResult;
    }
}
