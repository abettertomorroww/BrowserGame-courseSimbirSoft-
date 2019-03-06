using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BrowserGame_courseSimbirSoft_.Annotations;

namespace BrowserGame_courseSimbirSoft_.Models
{
 
    public class Character
    {
        public int Id { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrectly")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Range(0, 0)]
        [Display(Name = "Win")]
        public string Win { get; set; }

        [Required]
        [Range(0, 0)]
        [Display(Name = "Lose")]
        public string Lose { get; set; }

    }
}
