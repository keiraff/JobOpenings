using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobOpenings.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Email.")]
        [EmailAddress(ErrorMessage = "Email address is incorrect.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
