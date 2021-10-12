using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="Enter Author Name")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Enter Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
