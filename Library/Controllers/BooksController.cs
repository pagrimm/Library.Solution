using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  public class BooksController: Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BooksController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> bookList = _db.Books.Include(books => books.Authors).ThenInclude(join => join.Author).OrderBy(books => books.Title).ToList();
      return View(bookList);
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books..Include(books => books.Authors).ThenInclude(join => join.Author).FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    public ActionResult Create()
    {
      //ViewBag.Genre = new SelectList(_db.Books, "Genre", "Genre");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}