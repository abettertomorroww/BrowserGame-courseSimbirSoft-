using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame_courseSimbirSoft_.Services.Implementation
{
    public interface IUserService
    {

        /// <summary>
        /// регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        Task<IdentityResult> Register(User user, string pass);

        /// <summary>
        /// вход на сайт при регистрации
        /// </summary>
        /// <param name="user"></param>
        Task SignIn(User user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email">mail</param>
        /// <param name="pass"></param>
        /// <param name="rememberMe">Флаг запоминания на сайте</param>
        Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);

    }
}
