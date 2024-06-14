using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Items")]
public class Item
{
    [Key]
    public int id { get; set; }
    [MaxLength(100)]
    public string name { get; set; }
    public int weight{ get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
}