namespace QuizzApplication.Models
{
    public class QuestionResult
    {
        public string QuestionContent { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
