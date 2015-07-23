using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_2.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name *")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage="Пароль не может содержать менее 6 знаков")]
        [Display(Name = "Password *")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль не может содержать менее 6 знаков")]
        [Compare("Password")]
        [Display(Name = "Repeat Password *")]
        public string RepeatPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail *")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}