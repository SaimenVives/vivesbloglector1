using Microsoft.AspNetCore.Mvc;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var articles = GetArticles();
            return View(articles);
        }

        private IList<Article> GetArticles()
        {
            var articles = new List<Article>();

            for (int i = 0; i < 10; i++)
            {
                articles.Add(new Article
                {
                    Id = i,
                    Title = $"Article title {i}",
                    Description = $"This is about article {i}",
                    Content = $"The full content of article {i}",
                    Author = $"Bavo{i} Ketels{i}",
                    CreatedDate = DateTime.UtcNow.AddHours(-i)
                });
            }

            return articles;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var artikels = GetArticles();
            var article = artikels.FirstOrDefault(a => a.Id == id);

            if (article is null)
            {
                return RedirectToAction("Index");
            }

            return View("PersonDetail", article);
        }
    }
}