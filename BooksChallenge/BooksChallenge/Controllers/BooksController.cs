using AutoMapper;
using Contracts.Repositories;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksChallenge.Controllers
{
	/// <summary>
	/// The Books Controller.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : Controller
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Constructor of AuthorsController.
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="mapper"></param>
		public BooksController(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get the list of authors.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetBooks()
		{
			var books = await _repository.Book.GetAllBooksAsync(trackChanges: false);
			var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);

			return Ok(booksDTO);
		}

		/// <summary>
		/// Get book by Id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}", Name = "BookById")]
		public async Task<IActionResult> GetBook(Guid id)
		{
			var book = await _repository.Book.GetBookAsync(id, trackChanges: false);
			if (book is null)
				return NotFound();
			else
			{
				var bookDto = _mapper.Map<BookDTO>(book);
				return Ok(bookDto);
			}
		}
	}
}