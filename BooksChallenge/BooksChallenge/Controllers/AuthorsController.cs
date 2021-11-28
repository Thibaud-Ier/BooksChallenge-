using AutoMapper;
using Contracts.Repositories;
using Entities.DTO.Authors;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		public async Task<IActionResult> GetAuthors()
		{
			var authors = await _repository.Author.GetAllAuthorsAsync(trackChanges: false);
			var authorsDTO = _mapper.Map<IEnumerable<AuthorDto>>(authors);

			return Ok(authorsDTO);
		}

		/// <summary>
		/// Get author by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}", Name = "AuthorById")]
		public async Task<IActionResult> GetAuthor(Guid id)
		{
			var author = await _repository.Author.GetAuthorAsync(id, trackChanges: false);
			if (author is null)
				return NotFound();
			else
			{
				var authorDto = _mapper.Map<AuthorDto>(author);
				return Ok(authorDto);
			}
		}

		/// <summary>
		/// Create an author.
		/// </summary>
		/// <param name="author"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
		{
			if (author == null)
				return BadRequest("AuthorForCreationDto object is null");

			var authorEntity = _mapper.Map<Author>(author);

			_repository.Author.CreateAuthor(authorEntity);
			await _repository.SaveAsync();

			var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

			return CreatedAtRoute("AuthorById", new { id = authorToReturn.Id }, authorToReturn);
		}
	}
}