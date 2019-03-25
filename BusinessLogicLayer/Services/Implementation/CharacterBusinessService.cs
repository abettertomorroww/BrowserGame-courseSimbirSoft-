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


namespace DataLogicLayer.Services.Implementation
{
    internal class CharacterBusinessService : ICharacterBusinessService
    {
        private readonly ICharacterDataService characterService;

        public CharacterBusinessService(ICharacterDataService characterService)
        {
            this.characterService = characterService;
        }

        public async Task<IList<CharacterBusiness>> GetCharacters(string name)
        {
            var characterList = await characterService.GetCharacters(name);
            var character = new List<CharacterBusiness>();
            foreach (var s in characterList)
            {
                var characters = s.Adapt<CharacterBusiness>();
                character.Add(characters);
            }
            return character;
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

        public async Task CreateChar(CharacterBusiness character, string name, string operation)
        {
            var characterDatas = character.Adapt<CharacterData>();
            characterDatas.User = character.User;
            switch (operation)
            {
                case "add":
                    await this.characterService.CreataChar(characterDatas, name);
                    break;
                case "update":
                    await this.characterService.UpdateChar(characterDatas, name);
                    break;
            }
        }

        public IList<CharacterBusiness> EqualChar(string name, string operation, int? id)
        {
            IList<CharacterData> characterDatas = null;
            switch (operation)
            {
                case "add":
                    characterDatas = this.characterService.EqualChar(name);
                    break;
                case "update":
                    characterDatas = this.characterService.EqualCharUpdate(name, (int)id);
                    break;
            }
            var character = new List<CharacterBusiness>();
            foreach (var s in characterDatas)
            {
                var characters = s.Adapt<CharacterBusiness>();
                character.Add(characters);
            }
            return character;
        }


    }
}
