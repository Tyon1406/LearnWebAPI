using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnWebAPI.Models;
using LearnWebAPI.Services;
using LearnWebAPI.Dtos;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController(ICharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
         => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
            {
                return NotFound("Character with the given ID was not found.");
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var createdCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            var updated = await service.UpdateCharacterAsync(id, character);
            return updated ? NoContent() : NotFound("Character with the given Id was not found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            return deleted ? NoContent() : NotFound("Character with the given Id was not found.");
        }
    }
}
