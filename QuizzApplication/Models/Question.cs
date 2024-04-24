using System.ComponentModel.DataAnnotations;

namespace QuizzApplication.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public required string Content { get; set; }

        [Required(ErrorMessage = "Option 1 is required.")]
        public required string Option1 { get; set; }

        [Required(ErrorMessage = "Option 2 is required.")]
        public required string Option2 { get; set; }

        [Required(ErrorMessage = "Option 3 is required.")]
        public required string Option3 { get; set; }

        [Required(ErrorMessage = "Option 4 is required.")]
        public required string Option4 { get; set; }

        [Required(ErrorMessage = "Correct answer is required.")]
        public required string CorrectAnswer { get; set; }

        public bool IsCorrectAnswerValid()
        {
            var options = new List<string> { Option1, Option2, Option3, Option4 };
            return options.Contains(CorrectAnswer);
        }
    }
}
