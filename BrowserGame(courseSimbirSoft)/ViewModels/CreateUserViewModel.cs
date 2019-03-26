using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrowserGame_courseSimbirSoft_.ViewModels
{
    /// <summary>
    /// модель создания пользователя
    /// </summary>
    public class CreateUserViewModel
    {

        /// <summary>
        /// User Name
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in!")]
        public string Name { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in!")]
        public string Email { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required(ErrorMessage = "The field must be filled in!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
