using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	/// <summary>
	/// Represents a book.
	/// </summary>
	public class Book
	{
		/// <summary>
		/// Id of the book.
		/// </summary>
		[Column("BookId")]
		public Guid Id { get; set; }

		/// <summary>
		/// Name of the book.
		/// </summary>
		[Required(ErrorMessage = "Name is a required field.")]
		[MaxLength(300, ErrorMessage = "Maximum length for the Name is 300 characters.")]
		public string Name { get; set; }

		/// <summary>
		/// Isbn code of the book.
		/// </summary>
		[Required(ErrorMessage = "Isbn is a required field.")]
		[MinLength(10, ErrorMessage = "Minimum length for the Isbn is 10 characters.")]
		[MaxLength(13, ErrorMessage = "Maximum length for the Isbn is 13 characters.")]
		public string Isbn { get; set; }

		/// <summary>
		/// Author Id of the book.
		/// </summary>
		[ForeignKey(nameof(Author))]
		public Guid AuthorId { get; set; }

		/// <summary>
		/// Author of the book
		/// </summary>
		public Author Author { get; set; }
	}
}