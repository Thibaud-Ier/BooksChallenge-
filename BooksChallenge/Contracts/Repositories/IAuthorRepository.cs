using Entities.Models;
using System.Collections.Generic;

namespace Contracts.Repositories
{
	/// <summary>
	/// Interface for AuthorRepository.
	/// </summary>
	public interface IAuthorRepository
	{
		/// <summary>
		/// Get all authors.
		/// </summary>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		IEnumerable<Author> GetAllAuthors(bool trackChanges);
	}
}