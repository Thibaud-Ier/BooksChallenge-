using ApiTests.Fixtures;
using BooksChallenge.Controllers;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests
{
	public class BooksControllerTests : IClassFixture<ControllerWithDatabaseInMemoryFixture>
	{
		private readonly ControllerWithDatabaseInMemoryFixture _fixture;
		private readonly BooksController _controller;

		public BooksControllerTests(ControllerWithDatabaseInMemoryFixture fixture)
		{
			var repositoryManager = new RepositoryManager(fixture.Context);
			_fixture = fixture;
			_controller = new BooksController(repositoryManager, fixture.Mapper);
		}

		~BooksControllerTests()
		{
			_fixture.Dispose();
		}

		[Fact]
		public async Task Get_Books_Should_Give_Initial_Books()
		{
			var result = await _controller.GetBooks();

			var okResult = result as OkObjectResult;
			Assert.NotNull(okResult);
			Assert.Equal(200, okResult.StatusCode);
			var listBooks = okResult.Value as IEnumerable<BookDTO>;
			Assert.NotNull(listBooks);
			Assert.Equal(4, listBooks.Count());

			var book = listBooks.First(x => x.Id == new Guid("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd"));
			Assert.NotNull(book);
			Assert.Equal("L'Appel de la forêt", book.Name);
			Assert.Equal("2-253-03986-1", book.Isbn);
			Assert.Equal(new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), book.AuthorId);

			book = listBooks.First(x => x.Id == new Guid("d9f2bf68-50d4-457a-b053-52a5b10ca361"));
			Assert.NotNull(book);
			Assert.Equal("Le Loup des mers", book.Name);
			Assert.Equal("9782070332731", book.Isbn);
			Assert.Equal(new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), book.AuthorId);

			book = listBooks.First(x => x.Id == new Guid("11de9d1c-8d2e-47f2-bce7-d020aa4c9f60"));
			Assert.NotNull(book);
			Assert.Equal("Vingt Mille Lieues sous les mers", book.Name);
			Assert.Equal("9782253006329", book.Isbn);
			Assert.Equal(new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), book.AuthorId);

			book = listBooks.First(x => x.Id == new Guid("c146aff2-ec00-47dc-9afa-d331800b5e3f"));
			Assert.NotNull(book);
			Assert.Equal("Les Aventures du capitaine Hatteras", book.Name);
			Assert.Equal("9781520982076", book.Isbn);
			Assert.Equal(new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), book.AuthorId);
		}

		[Theory]
		[InlineData("b5fd448f-5b2d-4058-9bfd-cbb8b8b522fd", "L'Appel de la forêt", "2-253-03986-1", "3f9a0026-e78e-4307-a4df-c28470b7867d")]
		[InlineData("c146aff2-ec00-47dc-9afa-d331800b5e3f", "Les Aventures du capitaine Hatteras", "9781520982076", "7c8075c1-26fa-4a8b-9292-d22515a16ad7")]
		public async Task Get_Book_By_Id_Should_Give_The_Right_Book(string id, string name, string isbn, string authorId)
		{
			var result = await _controller.GetBook(new Guid(id));

			var okResult = result as OkObjectResult;
			Assert.NotNull(okResult);
			Assert.Equal(200, okResult.StatusCode);
			var book = okResult.Value as BookDTO;

			Assert.NotNull(book);
			Assert.Equal(new Guid(id), book.Id);
			Assert.Equal(name, book.Name);
			Assert.Equal(isbn, book.Isbn);
			Assert.Equal(new Guid(authorId), book.AuthorId);
		}

		[Fact]
		public async Task Get_Book_By_An_Non_Existant_Id_Should_Give_A_Not_Found()
		{
			var result = await _controller.GetBook(Guid.Empty);

			var notFoundResult = result as NotFoundResult;
			Assert.NotNull(notFoundResult);
			Assert.Equal(404, notFoundResult.StatusCode);
		}
	}
}