using Microsoft.AspNetCore.Mvc;
using Library.Models;
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
  [Authorize]
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
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userCopies = _db.Copies.Where(entry => entry.User.Id == currentUser.Id).ToList();
      // return View();

      List<Book> bookList = _db.Books.Include(books => books.Authors).ThenInclude(join => join.Author).OrderBy(books => books.Title).ToList();
      return View(bookList);
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books.Include(books => books.Authors)
      .ThenInclude(join => join.Author)
      .Include(books => books.Copies)
      .FirstOrDefault(books => books.BookId == id);
      ViewBag.CheckedOutCount = _db.Copies.Where(copy => copy.BookId == id).Where(copy => copy.IsCheckedOut == true).ToList().Count;
      ViewBag.AvailableCount = _db.Copies.Where(copy => copy.BookId == id).Where(copy => copy.IsCheckedOut == false).ToList().Count;
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

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
      // var thisBook = _db.Books  
      //   .Include(book => book.Authors)
      //   .ThenInclude(join => join.Author)
      //   .FirstOrDefault(book => book.BookId == id);
      // ViewBag.IsCurrentUser = userId != null ? userId == thisBook.User.Id : false;
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId ==  id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId ==  id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if (AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteAuthor(int joinId)
    {
      var authorBook = _db.AuthorBook.FirstOrDefault(join => join.AuthorBookId == joinId);
      _db.AuthorBook.Remove(authorBook);
      _db.SaveChanges();
      return RedirectToAction("Details", authorBook.BookId);
    }
  }
}