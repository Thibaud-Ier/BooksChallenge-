using System;

namespace Entities.DTO.Books
{
	/// <summary>
	/// Represents the books DTO.
	/// </summary>
	public class BookForCreationDto
	{
		/// <summary>
		/// Name of the book.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Isbn code of the book.
		/// </summary>
		public string Isbn { get; set; }

		/// <summary>
		/// Author Id of the book.
		/// </summary>
		public Guid AuthorId { get; set; }
	}
}