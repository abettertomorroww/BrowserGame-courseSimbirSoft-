﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame_courseSimbirSoft_.ViewModels
{
    public class RegisterViewModel
    {

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        [RegularExpression(@"^(?=.*[a-z])[A-Za-z\d@$!%^*?=#/&-_+`{|}~]{6,12}$", ErrorMessage = "{0} must contain at least one letter ('a'-'z'), be at least 6 and no more than 12 characters")]
        [Required(ErrorMessage = "The field must be filled in")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// подтверждение пароля
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordConfirm ")]
        public string PasswordConfirm { get; set; }
    }
}
