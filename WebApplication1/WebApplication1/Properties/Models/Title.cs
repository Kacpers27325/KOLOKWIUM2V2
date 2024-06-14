using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models;
[Table("Titles")]
public class Title
{
    [Key]
    public int id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
}