using Microsoft.EntityFrameworkCore;
using QuizzApplication.Models;

namespace QuizzApplication.Context
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
 
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    Content = "What is the capital of France?",
                    Option1 = "Paris",
                    Option2 = "London",
                    Option3 = "Berlin",
                    Option4 = "Madrid",
                    CorrectAnswer = "Paris"
                },
                new Question
                {
                    QuestionId = 2,
                    Content = "What is the capital of Germany?",
                    Option1 = "Paris",
                    Option2 = "London",
                    Option3 = "Berlin",
                    Option4 = "Madrid",
                    CorrectAnswer = "Berlin"
                }
                );
        }
    }
}
