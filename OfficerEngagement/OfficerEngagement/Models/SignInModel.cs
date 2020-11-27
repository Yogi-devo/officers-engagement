using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OfficerEngagement.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Login id is required")]
        [Display(Name = "Login Id")]
        public string LoginId { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get;  set; }
    }
}
