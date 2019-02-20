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
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Race")]
        [ValidRace(new string[] { "Elf", "Goblin", "Human", "Undead", "Orc" }, ErrorMessage = "Unacceptable race")]

        public string Race { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Ability")]
        

        public string Ability { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The length of the string must be between 2 to 20 characters")]
        [Display(Name = "Class")]
        public string Class { get; set; }
    }
}
