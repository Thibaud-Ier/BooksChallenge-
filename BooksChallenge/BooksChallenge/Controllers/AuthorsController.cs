using AutoMapper;
using Contracts.Repositories;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
		private readonly IMapper _mapper;

		/// <summary>
		/// Constructor of AuthorsController.
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="mapper"></param>
		public AuthorsController(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get the list of authors.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetAuthors()
		{
			var authors = _repository.Author.GetAllAuthors(trackChanges: false);
			var authorsDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authors);
			return Ok(authorsDTO);
		}
	}
}