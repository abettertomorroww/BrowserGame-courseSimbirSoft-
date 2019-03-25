using System.ComponentModel.DataAnnotations;

namespace DataLogicLayer.Models
{
    public class CharacterData

    {
        
        /// <summary>
        /// id игрока
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// имя игрока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// почта игрока
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// кол-во побед
        /// </summary>
        public int Win { get; set; }

        /// <summary>
        /// кол-во поражений
        /// </summary>
        public int Lose { get; set; }

        /// <summary>
        /// пользователь
        /// </summary>
        public string User { get; set; }
    }
}
