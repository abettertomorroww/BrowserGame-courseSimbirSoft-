using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Models;
using System.Threading.Tasks;


namespace BusinessLogicLayer.Services
{
    public interface ICharacterBusinessService
    {
        /// <summary>
        /// список персонажей
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IList<CharacterBusiness>> GetCharacters(string name);

        /// <summary>
        /// удаление персонажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteCharacterAsync(int id);

        /// <summary>
        /// редактирование персонажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CharacterBusiness> GetDetalies(int id);

        /// <summary>
        /// создание персонажа
        /// </summary>
        /// <param name="character"></param>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        Task CreateChar(CharacterBusiness character, string name, string operation);

        IList<CharacterBusiness> EqualChar(string name, string operation, int? id);
    }
}
