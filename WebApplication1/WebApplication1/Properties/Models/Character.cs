using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Characters")]
public class Character
{
    [Key]
    public int id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public int currentweight { get; set; }
    public int maxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    public ICollection<Character_Title> CharacterTitles { get; set; }
}