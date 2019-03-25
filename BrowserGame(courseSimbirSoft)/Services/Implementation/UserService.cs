using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.Services;
using BrowserGame_courseSimbirSoft_.ViewModels;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace BrowserGame_courseSimbirSoft_.Services.Implementation
{

    internal class UserService : IUserService
    {
        private readonly IUserBusinessService userServices;

        public UserService(IUserBusinessService userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IdentityResult> Register(User user, string pass)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return (await userServices.Register(baseUser, pass)).Adapt<IdentityResult>();
        }

        public Task SignIn(User user)
        {
            var baseUser = user.Adapt<UserBusiness>();
            return userServices.SignIn(baseUser);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return (await userServices.PasswordSignIn(email, pass, rememberMe)).Adapt<Microsoft.AspNetCore.Identity.SignInResult>();
        }

    }
}
