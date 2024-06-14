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
            return NotFound("Bohater nie istnieje");
        }

        if (res.ErrorCode == -2)
        {
            return NotFound("Przedmioty nie istnieją");
        }

        if (res.ErrorCode == -3)
        {
            return NotFound("Bohater nie ma wystarczającej siły, musi iść na siłownię");
        }

        return Ok(res);
    }
}