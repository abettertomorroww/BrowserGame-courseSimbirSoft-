using BrowserGame_courseSimbirSoft_.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace BrowserGame_courseSimbirSoft_.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        HomeController controller;

        [SetUp]
        public void Setup()
        {
            controller = new HomeController();
        }

        [Test]
        public void Index_ReturnView()
        {
            //arrange
            //act
            var result = controller.Index();
            //assert

            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.NotNull(result as ViewResult);
            Assert.AreEqual("Index", (result as ViewResult).ViewName);
        }

    }
}