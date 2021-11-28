using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
	/// <summary>
	/// Interface for BookRepository.
	/// </summary>
	public interface IBookRepository
	{
		/// <summary>
		/// Get all books.
		/// </summary>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);

		/// <summary>
		/// Get a book with its id.
		/// </summary>
		/// <param name="bookId"></param>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		Task<Book> GetBookAsync(Guid bookId, bool trackChanges);
	}
}