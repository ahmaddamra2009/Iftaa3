using Iftaa3.Data;
using Iftaa3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext db;

        public BooksController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult AllBooks()
        {
            var data = db.Books.Include(x => x.Author);
            return View(data);
        }
        public IActionResult CreateBook()
        {
            ViewBag.Auhtors = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(Book book, string btn, int[] catID)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
                var model = new BookCategory();
                for (int i = 0; i < catID.Length; i++)
                {
                    model.BookId = book.BookId;
                    model.CategoryId = catID[i];
                    db.BookCategories.Add(model);
                    db.SaveChanges();
                }

              

                return RedirectToAction("AllBooks");
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            return View(book);
        }
    }
}
