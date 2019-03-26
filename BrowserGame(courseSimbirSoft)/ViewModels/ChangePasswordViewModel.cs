using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame_courseSimbirSoft_.ViewModels
{
    /// <summary>
    /// модель изменения пароля
    /// </summary>
    public class ChangePasswordViewModel
    {

        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        [DataType(DataType.Password)]
        /// <summary>
        /// новый пароль
        /// </summary>
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You have not entered your old password")]
        /// <summary>
        /// старый пароль
        /// </summary>
        public string OldPassword { get; set; }
    }
}
