using Iftaa3.Data;
using Iftaa3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Controllers
{
    public class ViewModelExampleController : Controller
    {
        private AppDbContext db;
        public ViewModelExampleController(AppDbContext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            BookEmployeeViewModel model = new BookEmployeeViewModel
            {
                Employees = db.Employees.Include(x=>x.Department).ToList(),
                Authors=db.Authors.ToList(),
                Categories=db.Categories.ToList()
            };
            return View(model);
        }
    }
}
