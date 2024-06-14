using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Database;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Title> Titles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character_Title> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                id = 1,
                Name = "W pustyni i w puszczy"
            },
            new Title
            {
                id = 2,
                Name = "Gotuj z Wiesią"
            },
        });

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                id = 1,
                name = "Item 1",
                weight = 30
            },
            new Item
            {
                id = 2,
                name = "Item 2",
                weight = 40
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                currentweight = 200,
                maxWeight = 300
            },
            new Character
            {
                id = 2,
                FirstName = "Jakub",
                LastName = "Nowak",
                currentweight = 100,
                maxWeight = 150
            },
            new Character
            {
                id = 3,
                FirstName = "Alicja",
                LastName = "Drożdżówkowa",
                currentweight = 70,
                maxWeight = 120
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack
            {
                characterId = 1,
                itemId = 1,
                Amount = 5,
            },
            new Backpack
            {
                characterId = 2,
                itemId = 2,
                Amount = 3,
            },
            new Backpack
            {
                characterId = 1,
                itemId = 2,
                Amount = 5,
            }
        });

        modelBuilder.Entity<Character_Title>().HasData(new List<Character_Title>
        {
            new Character_Title
            {
                CharacterId = 1,
                TitleId = 1,
                AcquitedAt = DateTime.Parse("2024-05-28"),
            },
            new Character_Title
            {
                CharacterId = 2,
                TitleId = 2,
                AcquitedAt = DateTime.Parse("2024-05-28"),
            },
            new Character_Title
            {
                CharacterId = 1,
                TitleId = 2,
                AcquitedAt = DateTime.Parse("2024-05-28"),
            },
            new Character_Title
            {
                CharacterId = 2,
                TitleId = 1,
                AcquitedAt = DateTime.Parse("2024-05-28"),
            }
        });
    }
}