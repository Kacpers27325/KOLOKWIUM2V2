namespace WebApplication1.DTOs;

public class CharactersDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public ICollection<GetItemsDTO> Items { get; set; } = null!;
    public List<GetTitlesDTO> Titles { get; set; } = null!;
}

public class GetItemsDTO
{
    public string name { get; set; } = null!;
    public int weight{ get; set; }
    public int amount { get; set; }
}

public class GetTitlesDTO
{
    public string title { get; set; }
    public DateTime acquitedAt { get; set; }
}