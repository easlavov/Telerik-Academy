using System;

public class ExamResult
{
    private const int MIN_GRADE_BOTTOM_LIMIT = 0;

    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {   
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        set
        {
            if (value < MIN_GRADE_BOTTOM_LIMIT)
            {
                string message = string.Format("Grade must be at least {0}!", MIN_GRADE_BOTTOM_LIMIT);
                throw new ArgumentOutOfRangeException(message);
            }
            
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        set
        {
            if (value < MIN_GRADE_BOTTOM_LIMIT)
            {
                string message = string.Format("Min grade must be at least {0}!", MIN_GRADE_BOTTOM_LIMIT);
                throw new ArgumentOutOfRangeException(message);
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        set
        {
            if (value <= MIN_GRADE_BOTTOM_LIMIT)
            {
                string message = string.Format("Max grade must be at least {0}!", MIN_GRADE_BOTTOM_LIMIT + 1);
                throw new ArgumentOutOfRangeException(message);
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        set
        {
            if (value == null || value == string.Empty)
            {
                string message = "Comments can't be left null or empty!";
                throw new ArgumentNullException(message);
            }

            this.comments = value;
        }
    }
}
