using Entities.DTO.Books;
using System;
using System.Collections.Generic;

namespace Entities.DTO.Authors
{
	/// <summary>
	/// Represents an author DTO.
	/// </summary>
	public class AuthorDto
	{
		/// <summary>
		/// Id of the author.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// First Name of the author.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Last Name of the author.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		///	Books of the author.
		/// </summary>
		public ICollection<BookDto> Books { get; set; }
	}
}