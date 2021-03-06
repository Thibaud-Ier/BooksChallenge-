using AutoMapper;
using Contracts.Repositories;
using Entities.DTO.Books;
using Entities.Models;
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
		/// Constructor of BooksController.
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="mapper"></param>
		public BooksController(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Get the list of books.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetBooks()
		{
			var books = await _repository.Book.GetAllBooksAsync(trackChanges: false);
			var booksDTO = _mapper.Map<IEnumerable<BookDto>>(books);

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
				var bookDto = _mapper.Map<BookDto>(book);
				return Ok(bookDto);
			}
		}

		/// <summary>
		/// Create a book.
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
		{
			if (book == null)
				return BadRequest("BookForCreationDto object is null");

			var bookEntity = _mapper.Map<Book>(book);

			_repository.Book.CreateBook(bookEntity);
			await _repository.SaveAsync();

			var bookToReturn = _mapper.Map<BookDto>(bookEntity);

			return CreatedAtRoute("BookById", new { id = bookToReturn.Id }, bookToReturn);
		}

		/// <summary>
		/// Update a book.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="book"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookForUpdateDto book)
		{
			if (book == null)
				return BadRequest("BookForUpdateDto object is null");

			var bookEntity = await _repository.Book.GetBookAsync(id, trackChanges: true);
			if (bookEntity == null)
				return NotFound();

			_mapper.Map(book, bookEntity);
			await _repository.SaveAsync();

			return NoContent();
		}
	}
}