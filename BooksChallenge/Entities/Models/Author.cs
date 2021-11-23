using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	/// <summary>
	/// Represents an author.
	/// </summary>
	public class Author
	{
		/// <summary>
		/// Id of the author.
		/// </summary>
		[Column("AuthorId")]
		public Guid Id { get; set; }

		/// <summary>
		/// First Name of the author.
		/// </summary>
		[Required(ErrorMessage = "FirstName is a required field.")]
		[MaxLength(200, ErrorMessage = "Maximum length for the FirstName is 200 characters.")]
		public string FirstName { get; set; }

		/// <summary>
		/// Last Name of the author.
		/// </summary>
		[Required(ErrorMessage = "LastName is a required field.")]
		[MaxLength(200, ErrorMessage = "Maximum length for the LastName is 200 characters.")]
		public string LastName { get; set; }

		/// <summary>
		///	Books of the author.
		/// </summary>
		public ICollection<Book> Books { get; set; }
	}
}