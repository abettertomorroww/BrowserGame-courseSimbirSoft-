using BrowserGame_courseSimbirSoft_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


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
                new Character{Name="ALEX",Email="123@gmail.com",Win="0",Lose="0",Id=1},

            };
            foreach (Character s in userLogin)
            {
                context.Characters.Add(s);
            }
            context.SaveChanges();
        }
        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //context.Database.EnsureCreated();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            IdentityUser user = await UserManager.FindByEmailAsync("alex.kkk222@yandex.ru");
            var User = new IdentityUser();
            await UserManager.AddToRoleAsync(user, "Admin");

        }

    }
}
