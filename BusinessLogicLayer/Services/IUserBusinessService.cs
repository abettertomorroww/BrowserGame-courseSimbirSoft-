using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с пользователем
    /// </summary>
    public interface IUserBusinessService
    {
        /// <summary>
        /// регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        Task<IdentityResult> Register(UserBusiness user, string pass);

        /// <summary>
        /// вход на сайт при регистрации
        /// </summary>
        /// <param name="user"></param>
        Task SignIn(UserBusiness user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <param name="rememberMe">Флаг запоминания на сайте</param>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);
    }
}
