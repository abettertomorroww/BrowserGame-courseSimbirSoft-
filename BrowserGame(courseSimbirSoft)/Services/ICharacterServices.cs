using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.ViewModels;

namespace BrowserGame_courseSimbirSoft_.Services
{
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
        /// <param name="character"></param>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        Task<int> CreateChar(Character character, string name, string operation);

        /// <summary>
        /// список персонажей с идентчным параметру именем
        /// </summary>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Character> EqualChar(string name, string operation, int? id);

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
