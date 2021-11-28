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
	public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
	{
		public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
			await FindAll(trackChanges).OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToListAsync();

		public async Task<Author> GetAuthorAsync(Guid authorId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(authorId), trackChanges).SingleOrDefaultAsync();
	}
}