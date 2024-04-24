using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizzApplication.Models;

namespace QuizzApplication.Pages
{
    public class ScoreModel : PageModel
    {
        public List<QuestionResult> Results { get; private set; }
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }

        public void OnGet()
        {
            Results = JsonConvert.DeserializeObject<List<QuestionResult>>(TempData["Results"].ToString());
            Score = (int)TempData["Score"];
            TotalQuestions = Results.Count;
        }
    }
}
