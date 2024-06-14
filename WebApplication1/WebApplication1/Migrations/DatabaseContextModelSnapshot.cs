﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Database;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Backpack", b =>
                {
                    b.Property<int>("characterId")
                        .HasColumnType("int");

                    b.Property<int>("itemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("characterId", "itemId");

                    b.HasIndex("itemId");

                    b.ToTable("Backpacks");

                    b.HasData(
                        new
                        {
                            characterId = 1,
                            itemId = 1,
                            Amount = 5
                        },
                        new
                        {
                            characterId = 2,
                            itemId = 2,
                            Amount = 3
                        },
                        new
                        {
                            characterId = 1,
                            itemId = 2,
                            Amount = 5
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Character", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("currentweight")
                        .HasColumnType("int");

                    b.Property<int>("maxWeight")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            id = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            currentweight = 200,
                            maxWeight = 300
                        },
                        new
                        {
                            id = 2,
                            FirstName = "Jakub",
                            LastName = "Nowak",
                            currentweight = 100,
                            maxWeight = 150
                        },
                        new
                        {
                            id = 3,
                            FirstName = "Alicja",
                            LastName = "Drożdżówkowa",
                            currentweight = 70,
                            maxWeight = 120
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Character_Title", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquitedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("Character_Title");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquitedAt = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 2,
                            TitleId = 2,
                            AcquitedAt = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 2,
                            AcquitedAt = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 2,
                            TitleId = 1,
                            AcquitedAt = new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Item 1",
                            weight = 30
                        },
                        new
                        {
                            id = 2,
                            name = "Item 2",
                            weight = 40
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Title", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "W pustyni i w puszczy"
                        },
                        new
                        {
                            id = 2,
                            Name = "Gotuj z Wiesią"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Backpack", b =>
                {
                    b.HasOne("WebApplication1.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("characterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WebApplication1.Models.Character_Title", b =>
                {
                    b.HasOne("WebApplication1.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("WebApplication1.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });
#pragma warning restore 612, 618
        }
    }
}
