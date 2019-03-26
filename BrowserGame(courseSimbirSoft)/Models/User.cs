using DataLogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace BrowserGame_courseSimbirSoft_.Models
{
    /// <summary>
    /// модель пользователя
    /// </summary>
    public class User : UserData
    {

        /// <summary>
        /// User Name
        /// </summary>
        [DisplayName("Name")]
        public new string Name { get; set; }
    }
}
