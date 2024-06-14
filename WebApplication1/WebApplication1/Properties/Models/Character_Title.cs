using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Character_Title")]
[PrimaryKey(nameof(CharacterId),nameof(TitleId))]
public class Character_Title
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquitedAt { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } = null!;
    

}