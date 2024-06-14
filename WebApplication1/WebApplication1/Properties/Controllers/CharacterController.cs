using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/characters/{characterId}")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCharactersData(int characterId, CancellationToken cancellationToken)
    {
        var res = await _dbService.GetCharactersData(characterId, cancellationToken);

        if (res.currentWeight == -1)
        {
            return NotFound("There is no characters in the context!");
        }

        return Ok(res);
    }
}