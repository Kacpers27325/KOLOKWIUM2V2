using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/characters")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IDbService _dbService;

    public ItemController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("{characterID}/backpacks")]
    public async Task<IActionResult> AddItemsToCharacterBackpack(int characterID, [FromBody] List<int> itemIds,
        CancellationToken cancellationToken)
    {
        var res = await _dbService.AddItemsToCharacterBackpack(characterID, itemIds, cancellationToken);

        if (res.ErrorCode == -1)
        {
            return NotFound("Character does not exist!");
        }

        if (res.ErrorCode == -2)
        {
            return NotFound("Provided items do not exist!");
        }

        if (res.ErrorCode == -3)
        {
            return NotFound("Character cannot lift more!");
        }

        return Ok(res);
    }
}