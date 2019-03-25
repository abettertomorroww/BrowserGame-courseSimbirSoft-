using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLogicLayer.Models

{
    public class UserData : IdentityUser
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
    }
}
