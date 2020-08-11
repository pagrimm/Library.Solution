using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System;
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
  public class CopiesController : Controller
  {

    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CopiesController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      List<Copy> copyList = _db.Copies.Where(copy => copy.User.Id == userId).Include(copy => copy.Book).ToList();
      return View(copyList);
    }

    [HttpPost]
    public ActionResult Create (int BookId, int Copies)
    {
      //int copies = Int32.Parse(Copies);
      // var book = _db.Books.FirstOrDefault(books => books.BookId == BookId);
      for(int i = 1; i <= Copies; i++)
      {
        Copy newCopy = new Copy();
        newCopy.BookId = BookId;
        _db.Copies.Add(newCopy);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", "Books",  new { id = BookId } );
    }

    [HttpPost]
    public async Task<ActionResult> CheckOut(int BookId)
    {
      Copy copyToCheckOut = _db.Copies.Where(copy => copy.BookId == BookId).Where(copy => copy.IsCheckedOut != true).FirstOrDefault();
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      copyToCheckOut.User = currentUser;
      copyToCheckOut.CheckoutDate = DateTime.Today;
      copyToCheckOut.DueDate = DateTime.Today.AddDays(21);
      copyToCheckOut.IsCheckedOut = true;
      _db.Entry(copyToCheckOut).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Return (int CopyId)
    {
      var copy = _db.Copies.FirstOrDefault(c => c.CopyId == CopyId);
      copy.User = null;
      copy.IsCheckedOut = false;
      _db.Entry(copy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}