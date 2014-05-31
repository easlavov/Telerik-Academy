using System;

public class SimpleMathExam : Exam
{
    private const int MIN_POSSIBLE_SOLVED_PROBLEMS = 0;
    private const int MAX_POSSIBLE_SOLVED_PROBLEMS = 10;

    private const int MIN_POSSIBLE_GRADE = 2;
    private const int MAX_POSSIBLE_GRADE = 6;

    private const int REQUIRED_SOLVED_PROBLEMS_FOR_AVERAGE_GRADE = 4;
    private const int REQUIRED_SOLVED_PROBLEMS_FOR_EXCELLENT_GRADE = 7;

    private const int BAD_GRADE_AS_NUMBER = 2;
    private const int AVERAGE_GRADE_AS_NUMBER = 4;
    private const int EXCELLENT_GRADE_AS_NUMBER = 6;

    private int problemsSolved;
    
    public SimpleMathExam(int problemsSolved)
    {        
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        set
        {
            if (value < MIN_POSSIBLE_SOLVED_PROBLEMS)
            {
                string message = string.Format("Number of solved problems can't be smaller than {0}!",
                                               MIN_POSSIBLE_SOLVED_PROBLEMS);
                throw new ArgumentOutOfRangeException(message);
            }

            if (value > MAX_POSSIBLE_SOLVED_PROBLEMS)
            {
                string message = string.Format(
                                         "Number of solved problems can't be bigger than {0}!",
                                         MAX_POSSIBLE_SOLVED_PROBLEMS);
                throw new ArgumentOutOfRangeException(message);
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved < REQUIRED_SOLVED_PROBLEMS_FOR_AVERAGE_GRADE)
        {
            string comment = "Bad result: not enough tasks solved.";
            return new ExamResult(
                        BAD_GRADE_AS_NUMBER, 
                        MIN_POSSIBLE_GRADE, 
                        MAX_POSSIBLE_GRADE, 
                        comment);
        }
        else if (ProblemsSolved < REQUIRED_SOLVED_PROBLEMS_FOR_EXCELLENT_GRADE)
        {
            string comment = "Average result: some tasks solved.";
            return new ExamResult(
                        AVERAGE_GRADE_AS_NUMBER, 
                        MIN_POSSIBLE_GRADE, 
                        MAX_POSSIBLE_GRADE, 
                        comment);
        }
        else
        {
            string comment = "Excellent result: many tasks sovled.";
            return new ExamResult(
                        EXCELLENT_GRADE_AS_NUMBER, 
                        MIN_POSSIBLE_GRADE, 
                        MAX_POSSIBLE_GRADE, 
                        comment);
        }
    }
}
