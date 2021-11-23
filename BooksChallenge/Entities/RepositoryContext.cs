using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	/// <summary>
	/// Represents the context.
	/// </summary>
	public class RepositoryContext : DbContext
	{
		/// <summary>
		/// Build the context.
		/// </summary>
		/// <param name="options"></param>
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

		/// <summary>
		/// Intercept the creation of the model.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AuthorConfiguration());
			modelBuilder.ApplyConfiguration(new BookConfiguration());
		}

		/// <summary>
		/// DbSet of the Authors.
		/// </summary>
		public DbSet<Author> Authors { get; set; }

		/// <summary>
		/// DbSet of the Books.
		/// </summary>
		public DbSet<Book> Books { get; set; }
	}
}