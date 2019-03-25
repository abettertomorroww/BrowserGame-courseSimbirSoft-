using System.Linq;
using DataLogicLayer.Models;


namespace DataLogicLayer.Data
{
    public class CharacterInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Characters.Any())
            {
                return;
            }

            var userLogin = new CharacterData[]
            {
                new CharacterData{Name="Ivan", Email="123@gmail.com", Win=0, Lose=0, Id=1},

            };
            foreach (CharacterData s in userLogin)
            {
                context.Characters.Add(s);
            }
            context.SaveChanges();
        }
    }
}
