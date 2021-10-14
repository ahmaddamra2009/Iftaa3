using Iftaa3.Data;
using Iftaa3.Models;
using Iftaa3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext db;

        public HomeController(ILogger<HomeController> logger, AppDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AllEmployees()
        {
            var data = db.Employees.Include(x => x.Department);
            return View(data);
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            ViewBag.DepartmentNames = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AllEmployees");
                }
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View("CreateEmployee", employee);
            }
            ViewBag.DepartmentNames = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View("CreateEmployee", employee);
        }


        public IActionResult AllData1()
        {
            ViewBag.Employees = db.Employees.Include(x => x.Department).ToList();
            ViewBag.Books = db.Books.Include(x => x.Author);

            return View();
        }
        public IActionResult AllData2()
        {
            return View();
        }



        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = new User { UserName = model.UserName, Password = model.Password };

        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("AllEmployees");
        //    }
        //    return View(model);
          
        //}
    }
}
