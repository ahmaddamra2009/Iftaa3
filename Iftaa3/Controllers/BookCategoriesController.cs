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
    public class BookCategoriesController : Controller
    {
        private AppDbContext db;
        public BookCategoriesController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {

            return View(db.BookCategories.Include(x=>x.Book).Include(x=>x.Category));
        }


        public IActionResult Create()
        {
            ViewBag.Books = new SelectList(db.Books, "BookId", "BookName");
            ViewBag.cat = new SelectList(db.Categories, "CategoryId", "CategoryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCategory bookCategory)
        {
            db.BookCategories.Add(bookCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
