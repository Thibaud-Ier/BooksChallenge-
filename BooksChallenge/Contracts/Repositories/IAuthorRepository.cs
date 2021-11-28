using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
	}
}