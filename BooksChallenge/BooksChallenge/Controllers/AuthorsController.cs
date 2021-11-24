using Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksChallenge.Controllers
{
	/// <summary>
	/// The Authors Controller.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : Controller
	{
		private readonly IRepositoryManager _repository;

		/// <summary>
		/// Constructor of AuthorsController.
		/// </summary>
		/// <param name="repository"></param>
		public AuthorsController(IRepositoryManager repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Get the list of authors.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetAuthors()
		{
			var authors = _repository.Author.GetAllAuthors(trackChanges: false);
			return Ok(authors);
		}
	}
}