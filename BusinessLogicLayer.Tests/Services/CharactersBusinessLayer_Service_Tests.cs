using NUnit.Framework;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Implementation;
using DataLogicLayer.Models;
using DataLogicLayer.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using DataLogicLayer.Services.Implementation;

namespace BusinessLogicLayer.Tests
{
    [TestFixture]
    public class CharactersBusinessLayer_Service_Tests
    {
        Mock<ICharacterDataService> characterDataService;
        CharacterData modelData;
        CharacterBusinessService charactersService;
        CharacterBusiness modelBusiness;


        [SetUp]
        public void Setup()
        {
            modelData = new CharacterData { Id = 1, Name = "asd", Email = "asd@asd.asd", Lose = 0, Win = 0, User = "asd" };
            modelBusiness = new CharacterBusiness { Id = 1, Name = "asd", Email = "asd@asd.asd", Lose = 0, Win = 0, User = "asd" };
            characterDataService = new Mock<ICharacterDataService>();
            charactersService = new CharacterBusinessService(characterDataService.Object);
        }

        private List<CharacterData> GetTestCharacter()
        {
            var character = new List<CharacterData>
            {
                new CharacterData { Id = 1, Name = "asd", Email = "asd@asd.asd", Lose = 0, Win = 0, User = "asd" },
                new CharacterData { Id = 2, Name = "sda", Email = "sda@sda.sda", Lose = 0, Win = 0, User = "sda" },
            };
            return character;
        }

        [Test]
        public void DeleteCharacterAsync_CharacterId_ReturnTaskOfTypeBool()
        {
            //arrange
            //act
            var result = charactersService.DeleteCharacterAsync(1);
            
            //assert
            characterDataService.Verify(m => m.DeleteAsync(1));
            Assert.That(result, Is.TypeOf<Task<bool>>());
        }

        [Test]
        public async Task GetCharacter_ReturnListOfCharacterBusinessModel()
        {
            //arrange
            characterDataService.Setup(m => m.GetCharacters("User")).ReturnsAsync(GetTestCharacter());
            CharacterBusinessService _userServices = new CharacterBusinessService(characterDataService.Object);

            //act
            var result = await _userServices.GetCharacters("User");

            //assert
            Assert.AreEqual(GetTestCharacter().Count, result.Count);
            Assert.That(result, Is.TypeOf<List<CharacterBusiness>>());
        }

        [Test]
        public async Task GetDetails_returnCharacterBusinessModel()
        {
            //arrange
            characterDataService.Setup(m => m.GetDetails(1)).ReturnsAsync(modelData);
            CharacterBusinessService _userService = new CharacterBusinessService(characterDataService.Object);

            //act
            var result = await _userService.GetDetalies(1);

            //assert
            Assert.That(result, Is.TypeOf<CharacterBusiness>());
        }
    }
}