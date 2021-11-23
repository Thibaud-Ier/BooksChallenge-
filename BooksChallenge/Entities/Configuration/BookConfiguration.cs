using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
	/// <summary>
	/// Configuration of the Book table.
	/// </summary>
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		/// <summary>
		/// Creation of rows in the table.
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasData(
				new Book
				{
					Id = new Guid("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd"),
					Name = "L'Appel de la forêt",
					Isbn = "2-253-03986-1",
					AuthorId = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d")
				},
				new Book
				{
					Id = new Guid("d9f2bf68-50d4-457a-b053-52a5b10ca361"),
					Name = "Le Loup des mers",
					Isbn = "9782070332731",
					AuthorId = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d")
				},
				new Book
				{
					Id = new Guid("11de9d1c-8d2e-47f2-bce7-d020aa4c9f60"),
					Name = "Vingt Mille Lieues sous les mers",
					Isbn = "9782253006329",
					AuthorId = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7")
				},
				new Book
				{
					Id = new Guid("c146aff2-ec00-47dc-9afa-d331800b5e3f"),
					Name = "Les Aventures du capitaine Hatteras",
					Isbn = "9781520982076",
					AuthorId = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7")
				}
			);
		}
	}
}