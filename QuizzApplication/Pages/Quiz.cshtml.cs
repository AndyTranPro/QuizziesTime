using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizzApplication.Context;
using QuizzApplication.Models;

namespace QuizzApplication.Pages
{
    public class QuizModel : PageModel
    {
        private readonly QuizDbContext _context;
        public QuizModel(QuizDbContext context)
        {
            _context = context;
        }
        public List<Question> Questions { get; set; }
        public double Score { get; set; }
        private void RandomizeQuestions(List<Question> questions)
        {
            Random rng = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (questions[n], questions[k]) = (questions[k], questions[n]);
            }
        }
        public void OnGet()
        {
            var startTime = DateTime.Now;
            TempData["startTime"] = startTime.ToString();
            Questions = _context.Questions.ToList();
            RandomizeQuestions(Questions);
        }
        public IActionResult OnPost()
        {
            Questions = _context.Questions.ToList();
            int score = 0;
            var results = new List<QuestionResult>();

            foreach (var question in Questions)
            {
                string userAnswer = Request.Form[$"{question.QuestionId}"];
                bool isCorrect = userAnswer == question.CorrectAnswer;
                if (isCorrect)
                {
                    score++;
                }

                // Collecting detailed feedback for each question
                results.Add(new QuestionResult
                {
                    QuestionContent = question.Content,
                    UserAnswer = userAnswer,
                    CorrectAnswer = question.CorrectAnswer,
                    IsCorrect = isCorrect
                });
            }

            TempData["Results"] = JsonConvert.SerializeObject(results);
            TempData["Score"] = score;
            return RedirectToPage("/Score", new { score });
        }
    }
}
