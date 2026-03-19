using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnWebAPI.Models;
using LearnWebAPI.Services;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController(ICharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
         => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
            {
                return NotFound("Character with the given ID was not found.");
            }
            return Ok(character);
        }
    }
}
