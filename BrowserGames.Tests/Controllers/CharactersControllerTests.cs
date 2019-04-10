using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.Controllers;
using System.Linq;

namespace BrowserGame_courseSimbirSoft_.Tests
{
    [TestFixture]
    public class CharactersControllerTests
    {
        CharactersController controller;
        Mock<ICharacterServices> characters;
        Character characterModel;
        CharactersController CharactersControllerContext;


        [SetUp]
        public void SetUp()
        {
            characterModel = new Character { Id = 1, Email = "asd@asd.asd", Lose = 0, Name = "asd", User = "asd", Win = 0 };
            characters = new Mock<ICharacterServices>();
            controller = new CharactersController(characters.Object);

            CharactersControllerContext = new CharactersController(characters.Object);
            CharactersControllerContext.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "User")
                    }, "someAuthTypeName"))

                }
            };
        }

        private List<Character> GetCharactersTest()
        {
            var characters = new List<Character>
            {
                new Character {Id = 1, Email = "asd@asd.asd", Lose = 0, Name = "asd", User = "asd", Win = 0  },
                new Character {Id = 2, Email = "sss@sss.sss", Lose = 0, Name = "sss", User = "sss", Win = 0 },
            };
            return characters;
        }

        [Test]
        public async Task Index_GetCharactersTest_ReturnViewResult()
        {
            //arrange
            characters.Setup(m => m.GetCharacter("User")).ReturnsAsync(GetCharactersTest());
            var contr = new CharactersController(characters.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "User")
                    }, "someAuthTypeName"))

                    }
                }
            };

            //act
            var result = await contr.Index();

            //assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.IsAssignableFrom<List<Character>>((result as ViewResult).Model);
            Assert.AreEqual(GetCharactersTest().Count, ((result as ViewResult).Model as List<Character>).Count);
            Assert.AreEqual("sss", ((result as ViewResult).Model as List<Character>)[1].Name);
        }

        [Test]
        public async Task Edit_NullId_ReturnNotFoundResult()
        {
            //arrange
            //act 
            var result = await controller.Edit(null);
            //assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Details_NullId_ReturnNotFoundResult()
        {
            //arrange
            //act 
            var result = await controller.Details(null);
            //assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_NullId_ReturnNotFoundResult()
        {
            //arrange
            //act 
            var result = await controller.Delete(null);
            //assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Create_ModelStateIsValid_ReturnRedirectToAction()
        {
            //arrange
            //act 
            var result = await CharactersControllerContext.Create(characterModel);

            //assert
            characters.Verify(m => m.CreateChar(characterModel));
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteConfirmed_ReturnRedirectToAction()
        {
            //arrange
            //act
            var result = await controller.DeleteConfirmed(1);

            //assert
            characters.Verify(m => m.DeleteCharacterAsync(1));
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task Edit_ModelStateIsValid_ReturnRedirectToAction()
        {
            //arrange
            //act
            var result = await CharactersControllerContext.Edit(characterModel.Id, characterModel);

            //assert
            characters.Verify(m => m.UpdateChar(characterModel));
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }
    }    
}
