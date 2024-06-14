using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<CharactersDto> GetCharactersData(int characterId, CancellationToken cancellationToken);

    public Task<CharacterBackpackItems> AddItemsToCharacterBackpack(int characterId, List<int> itemIds,
        CancellationToken cancellationToken);
}