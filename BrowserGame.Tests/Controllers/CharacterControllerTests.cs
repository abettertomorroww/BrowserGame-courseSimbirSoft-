using BrowserGame_courseSimbirSoft_.Controllers;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BrowserGame_courseSimbirSoft_.ViewModels;
using System.Linq;

namespace BrowserGame.Tests.Controllers
{
    [TestFixture]
    public class CharacterControllerTests
    {
        CharactersController controller;
        Mock<ICharacterServices> characterServices;
        Character character;

        public List<Character> GetTestChar()
        {
            var character = new List<Character>
            {
                new Character { Id=1 , Name = "asd", Email ="ads@ad.ru", Win = 0, Lose = 0, User = "asd"}
            };
            return character;
        }

        [Test]
        public async Task Index_GetTestCharacters_ReturnViewResult()
        {
            characterServices.Setup(m => m.GetCharacter("User")).ReturnsAsync(GetTestChar());
        }
    }

    
}
