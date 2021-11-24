﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksChallenge.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20211123012243_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AuthorId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"),
                            FirstName = "Jack",
                            LastName = "London"
                        },
                        new
                        {
                            Id = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"),
                            FirstName = "Jules",
                            LastName = "Verne"
                        });
                });

            modelBuilder.Entity("Entities.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BookId");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd"),
                            AuthorId = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"),
                            Isbn = "2-253-03986-1",
                            Name = "L'Appel de la forêt"
                        },
                        new
                        {
                            Id = new Guid("d9f2bf68-50d4-457a-b053-52a5b10ca361"),
                            AuthorId = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"),
                            Isbn = "9782070332731",
                            Name = "Le Loup des mers"
                        },
                        new
                        {
                            Id = new Guid("11de9d1c-8d2e-47f2-bce7-d020aa4c9f60"),
                            AuthorId = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"),
                            Isbn = "9782253006329",
                            Name = "Vingt Mille Lieues sous les mers"
                        },
                        new
                        {
                            Id = new Guid("c146aff2-ec00-47dc-9afa-d331800b5e3f"),
                            AuthorId = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"),
                            Isbn = "9781520982076",
                            Name = "Les Aventures du capitaine Hatteras"
                        });
                });

            modelBuilder.Entity("Entities.Models.Book", b =>
                {
                    b.HasOne("Entities.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Entities.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}