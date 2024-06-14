using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<CharactersDto> GetCharactersData(int characterId, CancellationToken cancellationToken)
    {
        if (await DoesCharacterExist(characterId, cancellationToken) == false)
        {
            return new CharactersDto { currentWeight = -1 };
        }

        var charactersDto = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .Where(c => c.id == characterId)
            .Select(c => new CharactersDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                currentWeight = c.currentweight,
                maxWeight = c.maxWeight,
                Items = c.Backpacks.Select(b => new GetItemsDTO
                {
                    name = b.Item.name,
                    weight = b.Item.weight,
                    amount = b.Amount
                }).ToList(),
                Titles = c.CharacterTitles.Select(ct => new GetTitlesDTO
                {
                    title = ct.Title.Name,
                    acquitedAt = ct.AcquitedAt
                }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);

        return charactersDto!;
    }

    public async Task<CharacterBackpackItems> AddItemsToCharacterBackpack(int characterId, List<int> itemIds,
        CancellationToken cancellationToken)
    {
        if (await DoesCharacterExist(characterId, cancellationToken) == false)
        {
            return new CharacterBackpackItems { ErrorCode = -1 };
        }

        if (!await DoesItemsExist(itemIds, cancellationToken))
        {
            return new CharacterBackpackItems { ErrorCode = -2 };
        }

        if (!await DoesCharacterCanLift(characterId, itemIds, cancellationToken))
        {
            return new CharacterBackpackItems { ErrorCode = -3 };
        }

        var character = await _context
            .Characters
            .Where(c => c.id == characterId)
            .FirstOrDefaultAsync(cancellationToken);


        foreach (var itemId in itemIds)
        {
            var existingBackpackItem = character!.Backpacks.FirstOrDefault(b => b.itemId == itemId);

            if (existingBackpackItem != null)
            {
                existingBackpackItem.Amount++;
            }
            else
            {
                await _context
                    .Backpacks
                    .AddAsync(new Backpack
                    {
                        characterId = characterId,
                        itemId = itemId,
                        Amount = 1,
                    }, cancellationToken);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        var characterBackpackItems = new CharacterBackpackItems();

        var characterBackpacks = await _context
            .Backpacks
            .Where(b => b.characterId == characterId)
            .Select(b => new BackpackDto
            {
                Amount = b.Amount,
                ItemId = b.itemId,
                CharacterId = b.characterId
            })
            .ToListAsync(cancellationToken);

        characterBackpackItems.BackpackItems = characterBackpacks;

        return characterBackpackItems;
    }

    private async Task<bool> DoesCharacterExist(int characterId, CancellationToken cancellationToken)
    {
        var res = await _context
            .Characters
            .Where(c => c.id == characterId)
            .FirstOrDefaultAsync(cancellationToken);

        return res != null;
    }

    private async Task<bool> DoesItemsExist(List<int> itemIds, CancellationToken cancellationToken)
    {
        var existingItems = await _context.Items
            .Where(i => itemIds.Contains(i.id))
            .Select(i => i.id)
            .ToListAsync(cancellationToken);

        return existingItems.Count == itemIds.Count;
    }

    private async Task<bool> DoesCharacterCanLift(int characterId, IEnumerable<int> itemIds,
        CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .FirstOrDefaultAsync(c => c.id == characterId, cancellationToken);

        var totalWeight = itemIds.Sum(itemId =>
            character!.Backpacks.FirstOrDefault(b => b.itemId == itemId)!.Item.weight);

        return totalWeight <= character!.maxWeight;
    }
}