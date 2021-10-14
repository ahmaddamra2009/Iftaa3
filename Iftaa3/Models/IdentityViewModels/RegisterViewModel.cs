using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Models.IdentityViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Enter Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password")]
        [Compare("Password",ErrorMessage ="Password not match ....")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

    }
}
