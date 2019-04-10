using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataLogicLayer.Models;
using Mapster;
using System.Threading.Tasks;
using DataLogicLayer.Services;
using DataLogicLayer.Services.Implementation;
using System.Linq;

namespace DataLogicLayer.Services.Implementation
{
    public class CharacterBusinessService : ICharacterBusinessService
    {
        private readonly ICharacterDataService characterService;

        public CharacterBusinessService(ICharacterDataService characterService)
        {
            this.characterService = characterService;
        }

        public async Task<IList<CharacterBusiness>> GetCharacters(string name)
        {
            var characterList = await characterService.GetCharacters(name);
            return characterList.Select(s => (s.Adapt<CharacterBusiness>())).ToList();
        }

        public Task DeleteCharacterAsync(int id)
        {
            return characterService.DeleteAsync(id);
        }

        public async Task<CharacterBusiness> GetDetalies(int id)
        {
            var characterList = await characterService.GetDetails(id);
            return characterList.Adapt<CharacterBusiness>();
        }

        public async Task CreateChar(CharacterBusiness character)
        {
            var characterList = character.Adapt<CharacterData>();
            characterList.Id = character.Id;
            await this.characterService.CreateChar(characterList);
        }

       public async Task UpdateChar(CharacterBusiness character)
        {
            var characterList = character.Adapt<CharacterData>();
            characterList.Id = character.Id;
            await this.characterService.UpdateChar(characterList);
        }


    }
}
