using BrowserGame_courseSimbirSoft_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BrowserGame_courseSimbirSoft_.Data
{
    public class InitializerDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Characters.Any())
            {
                return;
            }

            var userLogin = new Character[]
            {
                new Character{Name="Tresdin",Race="Human",Ability="Vampirism",Class="Warrior",Id=1},
                new Character{Name="Razzil",Race="Goblin",Ability="Regeneration",Class="Mechanic",Id=2},
                new Character{Name="Traxex",Race="Elf",Ability="High attack speed",Class="Assassin",Id=3}
            };
            foreach (Character s in userLogin)
            {
                context.Characters.Add(s);
            }
            context.SaveChanges();
        }
    }
}
