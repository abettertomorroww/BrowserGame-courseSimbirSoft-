using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using BrowserGame_courseSimbirSoft_.Controllers;
using BrowserGame_courseSimbirSoft_.Services;
using DataLogicLayer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BrowserGame_courseSimbirSoft_.Tests
{
    [TestFixture]
    public class RolesControllerTests
    {
        public class FakeRoleManager : RoleManager<IdentityRole>
        {
            public FakeRoleManager()
                 : base(new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object)
            { }
        }

        public class FakeUserManager : UserManager<IdentityUser>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<IdentityUser>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<IdentityUser>>().Object,
                      new IUserValidator<IdentityUser>[0],
                      new IPasswordValidator<IdentityUser>[0],
                      new Mock<ILookupNormalizer>().Object,
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<IdentityUser>>>().Object)
            { }
        }

        RolesController controller;
        Mock<FakeRoleManager> _roleManagerMock;
        Mock<FakeUserManager> _userManagerMock;

        [SetUp]
        public void SetUp()
        {
            controller = new RolesController(_roleManagerMock.Object, _userManagerMock.Object);
            _roleManagerMock = new Mock<FakeRoleManager>();
            _userManagerMock = new Mock<FakeUserManager>();
        }


        [Test]
        public async Task Create_RedirectToIndex()
        {
            //arrange
            _roleManagerMock.Setup(m => m.CreateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);

            //act
            var result = await controller.Create("role");

            //assert
            _roleManagerMock.Verify(m => m.CreateAsync(It.IsAny<IdentityRole>()));
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public async Task Edit_RedirectToUserList()
        {
            //arrange
            List<string> allRoles = new List<string> { };
            IdentityUser userData = new IdentityUser
            {
                Id = "1"
            };

            _userManagerMock.Setup(m => m.FindByIdAsync("name")).ReturnsAsync(userData);
            _userManagerMock.Setup(m => m.GetRolesAsync(userData)).ReturnsAsync(allRoles);

            //act
            var result = await controller.Edit("name", allRoles);

            //assert
            Assert.AreEqual("UserList", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public async Task Edit_NullId_ReturnNotFoundResult()
        {
            //arrange
            //act
            var result = await controller.Edit(null);

            //arrange
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_NullId_ReturnNotFoundResult()
        {
            //arrange
            //act
            var result = await controller.Delete(null);

            //arrange
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_RedirectToIndex()
        {
            //arrange
            IdentityRole role = new IdentityRole { Id = "roleId" };

            _roleManagerMock.Setup(m => m.FindByIdAsync("role")).ReturnsAsync(role);

            RolesController contr = new RolesController(_roleManagerMock.Object, _userManagerMock.Object);

            //act
            var result = await contr.Delete("role");

            //assert
            _roleManagerMock.Verify(m => m.DeleteAsync(role));
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }
    }
}
