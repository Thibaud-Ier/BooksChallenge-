using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
	/// <summary>
	/// Configuration of the Author table.
	/// </summary>
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		/// <summary>
		/// Creation of rows in the table.
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.HasData(
				new Author
				{
					Id = new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"),
					FirstName = "Jack",
					LastName = "London"
				},
				new Author
				{
					Id = new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"),
					FirstName = "Jules",
					LastName = "Verne"
				}
			);
		}
	}
}