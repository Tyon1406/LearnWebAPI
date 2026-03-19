using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        static List<Character> characters = new List<Character>()
        {
            new Models.Character { Id = 1, Name = "Zed", Game = "League of Legend", Role = "Assasin" },
            new Models.Character { Id = 2, Name = "Airi", Game = "Arena of Valor", Role = "Bruiser" },
            new Models.Character { Id = 3, Name = "Cloud", Game = "Final Fantasy XII", Role = "Wanderer" },
            new Models.Character { Id = 4, Name = "Luffy", Game = "One piece", Role = "Captain"}
        };

        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync()
            => await Task.FromResult(characters);

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            var result = characters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
