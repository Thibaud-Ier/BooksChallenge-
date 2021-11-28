namespace Entities.DTO
{
	/// <summary>
	/// Represents the DTO for the creation of an author.
	/// </summary>
	public class AuthorForCreationDto
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