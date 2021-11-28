using Contracts.Repositories;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
	public class BookRepository : RepositoryBase<Book>, IBookRepository
	{
		public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
			await FindAll(trackChanges).OrderBy(a => a.Name).ToListAsync();

		public async Task<Book> GetBookAsync(Guid bookId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(bookId), trackChanges).SingleOrDefaultAsync();
	}
}