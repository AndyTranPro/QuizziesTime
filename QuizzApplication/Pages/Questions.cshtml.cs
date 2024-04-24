using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizzApplication.Context;
using QuizzApplication.Models;

namespace QuizzApplication.Pages
{
    public class QuestionsModel : PageModel
    {
        private readonly QuizDbContext _context;

        public QuestionsModel(QuizDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; }

        public List<Question> Questions { get; set; }

        public void OnGet()
        {
            Questions = [.._context.Questions];
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && Question.IsCorrectAnswerValid())
            {
                Console.WriteLine(Question);
                _context.Questions.Add(Question);
                _context.SaveChanges();
                return RedirectToPage("./Questions");
            }
            if (!Question.IsCorrectAnswerValid())
            {
                ModelState.AddModelError("Question.CorrectAnswer", "Correct answer must be one of the options.");
            }

            return Page();
        }

        public IActionResult OnPostUpdate(int id)
        {
            var questionToUpdate = _context.Questions.Find(id);

            if (questionToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            questionToUpdate.Content = Question.Content;
            questionToUpdate.Option1 = Question.Option1;
            questionToUpdate.Option2 = Question.Option2;
            questionToUpdate.Option3 = Question.Option3;
            questionToUpdate.Option4 = Question.Option4;
            questionToUpdate.CorrectAnswer = Question.CorrectAnswer;
            _context.SaveChanges();

            return RedirectToPage("./Questions");
        }
    }
}
