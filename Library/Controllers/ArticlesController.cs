using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
  public class ArticlesController: Controller
  {
    public IActionResult Index(string query, string type)
    {
      var articles = Article.GetArticles(query, type);
      return View(articles);
    }
  }
}