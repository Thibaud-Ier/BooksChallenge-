namespace Entities.DTO.Authors
{
	/// <summary>
	/// Represents the DTO for the update of an author.
	/// </summary>
	public class AuthorForUpdateDto
	{
		/// <summary>
		/// Represents the first name of the author.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Represents the last name of the author.
		/// </summary>
		public string LastName { get; set; }
	}
}