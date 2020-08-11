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
  public class CopiesController : Controller
  {

    private readonly LibraryContext _db;

    public CopiesController(LibraryContext db)
    {
      _db = db;
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
  }
}