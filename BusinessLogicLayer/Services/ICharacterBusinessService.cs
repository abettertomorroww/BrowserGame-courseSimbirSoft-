using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Models;
using System.Threading.Tasks;


namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// интерфейс работы с персонажем
    /// </summary>
    public interface ICharacterBusinessService
    {
        /// <summary>
        /// список персонажей
        /// </summary>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        Task<IList<CharacterBusiness>> GetCharacters(string name);

        /// <summary>
        /// удаление персонажа
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        Task DeleteCharacterAsync(int id);

        /// <summary>
        /// редактирование персонажа
        /// </summary>
        /// <param name="id">индификатор персонажа</param>
        /// <returns></returns>
        Task<CharacterBusiness> GetDetalies(int id);


        /// <summary>
        /// имя персонажа
        /// </summary>
        /// <param name="character">персонаж</param>
        /// <returns></returns>
        Task CreateChar(CharacterBusiness character);

        /// <summary>
        /// обновляем персонажа
        /// </summary>
        /// <param name="character">персонаж</param>
        /// <returns></returns>
        Task UpdateChar(CharacterBusiness character);
    }
}
