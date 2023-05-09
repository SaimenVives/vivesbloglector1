using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var articles = GetArticles();
            return View(articles);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IList<Article> GetArticles()
        {
            var articles = new List<Article>();

            for (int i = 0; i < 10; i++)
            {
                articles.Add(new Article
                {
                    Title = $"Article title {i}",
                    Description = $"This is about article {i}",
                    Content = $"The full content of article {i}",
                    Author = $"Bavo{i} Ketels{i}",
                    CreatedDate = DateTime.UtcNow.AddHours(-i)
                });
            }

            return articles;
        }
    }
}