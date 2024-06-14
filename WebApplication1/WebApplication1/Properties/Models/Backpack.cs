using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Backpacks")]
[PrimaryKey(nameof(characterId), nameof(itemId))]
public class Backpack
{
    public int characterId { get; set; }
    public int itemId { get; set; }

    public int Amount { get; set; }

    //klucze obce
    [ForeignKey(nameof(characterId))] public Character Character { get; set; } = null;
    [ForeignKey(nameof(itemId))] public Item Item { get; set; } = null;
}