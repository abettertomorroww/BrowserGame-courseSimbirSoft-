using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;

namespace BrowserGame_courseSimbirSoft_.Services
{
    /// <summary>
    /// интерфейс работы с персонажеми
    /// </summary>
    public interface ICharacterServices
    {


        /// <summary>
        /// список персонажей
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Character>> GetCharacter(string name);

        /// <summary>
        /// создание персонажа
        /// </summary>
        /// <param name="character">персонаж</param>
        /// <returns></returns>
        Task<int> CreateChar(Character character);

        /// <summary>
        /// обновление персонажа
        /// </summary>
        /// <param name="character">персонаж</param>
        /// <returns></returns>
        Task<int> UpdateChar(Character character);

        /// <summary>
        /// удаления персонажа 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        Task DeleteCharacterAsync(int id);

        /// <summary>
        /// нахождение персонажа по по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Character> GetDetails(int id);


    }
}
