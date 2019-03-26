using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BrowserGame_courseSimbirSoft_.ViewModels
{
    /// <summary>
    /// модель изменения ролей
    /// </summary>
    public class ChangeRoleViewModel
    {

        /// <summary>
        /// id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// список всех ролей
        /// </summary>
        public List<IdentityRole> AllRoles { get; set; }

        /// <summary>
        /// список ролей пользователя
        /// </summary>
        public IList<string> UserRoles { get; set; }

        /// <summary>
        /// конструктор изменения ролей
        /// </summary>
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
