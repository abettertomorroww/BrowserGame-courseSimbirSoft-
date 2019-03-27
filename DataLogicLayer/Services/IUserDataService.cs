using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLogicLayer.Models;


namespace DataLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с пользователем (БД)
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// регистрация пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <param name="pass">пароль</param>
        Task<IdentityResult> Register(UserData user, string pass);

        /// <summary>
        /// вход на сайт при регистрации
        /// </summary>
        /// <param name="user">пользователь</param>
        Task SignIn(UserData user);

        /// <summary>
        /// вход на сайт по паролю
        /// </summary>
        /// <param name="email">e-mail</param>
        /// <param name="pass">пароль</param>
        /// <param name="rememberMe">флаг запоминания на сайте</param>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);
    }
}
