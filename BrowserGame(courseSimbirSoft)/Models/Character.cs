using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BrowserGame_courseSimbirSoft_.Models
{
    /// <summary>
    /// модель персонажа
    /// </summary>
    public class Character
    {

        /// <summary>
        /// id персонажа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// имя 
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// почта
        /// </summary>
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrectly")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// побед
        /// </summary>
        [Required]
        [Range(0, 0)]
        [Display(Name = "Win")]
        public int Win { get; set; }

        /// <summary>
        /// поражений
        /// </summary>
        [Required]
        [Range(0, 0)]
        [Display(Name = "Lose")]
        public int Lose { get; set; }

        /// <summary>
        /// пользователь
        /// </summary>
        [Display(Name = "User")]
        public string User { get; set; }

    }
}
