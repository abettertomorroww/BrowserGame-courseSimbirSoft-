using System.Linq;
using DataLogicLayer.Data;
using DataLogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DataLogicLayer.Services.Implementation
{
    internal class CharacterDataService : ICharacterDataService
    {
        private ApplicationDbContext db;
        public CharacterDataService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task DeleteAsync(int id)
        {
            var charactes = await db.Characters.FindAsync(id);
            db.Characters.Remove(charactes);
            await db.SaveChangesAsync();
        }

        public async Task<IList<CharacterData>> GetCharacters(string name)
        {
            var userCharacters = db.Characters
                .Where(m => m.Name == name || m.Name == "Default");
            return await userCharacters.ToListAsync();
        }

        public async Task<CharacterData> GetDetails(int id)
        {
            var characters = db.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            return await characters;
        }

        public async Task CreataChar(CharacterData character, string name)
        {
            db.Characters.Add(character);
            await db.SaveChangesAsync();
        }

        public async Task UpdateChar(CharacterData characters, string name)
        {
            db.Characters.Update(characters);
            await db.SaveChangesAsync();
        }

        public IList<CharacterData> EqualChar(string name)
        {
            IQueryable<CharacterData> equalChar = db.Characters
                .Where(m => m.Name == name);
            return equalChar.ToList();
        }

        public IList<CharacterData> EqualCharUpdate(string name, int id)
        {
            IQueryable<CharacterData> equalChar = db.Characters
                .Where(m => m.Name == name && m.Id != id);
            return equalChar.ToList();
        }
    }
}
