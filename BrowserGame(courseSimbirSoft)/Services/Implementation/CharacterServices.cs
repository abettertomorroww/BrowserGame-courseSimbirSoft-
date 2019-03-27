using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;
using Mapster;



namespace BrowserGame_courseSimbirSoft_.Services.Implementation
{

    internal class CharacterServices : ICharacterServices
    {
        private readonly ICharacterBusinessService characterData;

        public CharacterServices(ICharacterBusinessService characterData)
        {
            this.characterData = characterData;
        }
        public Task DeleteCharacterAsync(int id)
        {
            return characterData.DeleteCharacterAsync(id);
        }

        public async Task<IEnumerable<Character>> GetCharacter(string name)
        {
            return (await characterData.GetCharacters(name)).Adapt<IEnumerable<Character>>();
        }

        public async Task<Character> GetDetails(int id)
        {
            return (await characterData.GetDetalies(id)).Adapt<Character>();
        }

        public async Task<int> CreateChar(Character character)
        {
            var characterList = character.Adapt<CharacterBusiness>();
            await this.characterData.CreateChar(characterList);
            return characterList.Id;
        }

        public async Task<int> UpdateChar(Character character)
        {
            var characterList = character.Adapt<CharacterBusiness>();
            await this.characterData.UpdateChar(characterList);
            return characterList.Id;
        }


    }
}
