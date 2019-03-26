using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame_courseSimbirSoft_.ViewModels
{
    /// <summary>
    /// модель добавления пользователя
    /// </summary>
    public class EditUserViewModel
    {

        /// <summary>
        /// User id
        /// </summary>
        public string Id { get; set; }

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



    }
}
