using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa3.Models.IdentityViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage ="Enter Role Name")]
        [Display(Name ="Role Name")]
        [MinLength(4,ErrorMessage ="Enter mini 4 Char for role name")]
        public string RoleName { get; set; }
    }
}
