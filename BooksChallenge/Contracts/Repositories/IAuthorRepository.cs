using Entities.Models;
using System;
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

		/// <summary>
		/// Get an author with its id.
		/// </summary>
		/// <param name="authorId"></param>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		Task<Author> GetAuthorAsync(Guid authorId, bool trackChanges);

		/// <summary>
		/// Create an author.
		/// </summary>
		/// <param name="author"></param>
		void CreateAuthor(Author author);
	}
}