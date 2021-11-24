using Contracts.Repositories;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
	public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
	{
		public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public IEnumerable<Author> GetAllAuthors(bool trackChanges) =>
			FindAll(trackChanges).OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();
	}
}