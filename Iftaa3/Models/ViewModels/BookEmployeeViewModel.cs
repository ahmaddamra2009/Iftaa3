 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Models.ViewModels
{
    public class BookEmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}
