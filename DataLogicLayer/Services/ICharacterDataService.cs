using DataLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataLogicLayer.Services
{
    /// <summary>
    /// интерфейс для работы с персонажем (БД)
    /// </summary>
    public interface ICharacterDataService
    {
        /// <summary>
        /// список персонажей (БД)
        /// </summary>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        Task<IList<CharacterData>> GetCharacters(string name);

        /// <summary>
        /// удаление персонажа (БД)
        /// </summary>
        /// <param name="id">id персонажа</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// нахождение персонажа по id (БД)
        /// </summary>
        /// <param name="id">id персонажа</param>
        /// <returns></returns>
        Task<CharacterData> GetDetails(int id);

        /// <summary>
        /// создание персонажа(БД)
        /// </summary>
        /// <param name="characters">персонаж</param>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        Task CreataChar(CharacterData characters, string name);

        /// <summary>
        /// редактирование персонажа (БД)
        /// </summary>
        /// <param name="characters">персонаж</param>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        Task UpdateChar(CharacterData characters, string name);

        /// <summary>
        /// получаем список имен юзеров с индетичным id (БД)
        /// </summary>
        /// <param name="name">имя персонажа</param>
        /// <returns></returns>
        IList<CharacterData> EqualChar(string name);

        /// <summary>
        /// получаем список имен юзеров с индетичным id (БД)
        /// </summary>
        /// <param name="name">имя персонажа</param>
        /// <param name="id">id персонажа</param>
        /// <returns></returns>
        IList<CharacterData> EqualCharUpdate(string name, int id);
    }
}
