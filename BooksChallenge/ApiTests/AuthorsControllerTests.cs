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
	public class AuthorsControllerTests : IClassFixture<ControllerWithDatabaseInMemoryFixture>
	{
		private readonly ControllerWithDatabaseInMemoryFixture _fixture;
		private readonly AuthorsController _controller;

		public AuthorsControllerTests(ControllerWithDatabaseInMemoryFixture fixture)
		{
			var repositoryManager = new RepositoryManager(fixture.Context);
			_fixture = fixture;
			_controller = new AuthorsController(repositoryManager, fixture.Mapper);
		}

		[Fact]
		public async Task Get_Authors_Should_Give_Initial_Authors()
		{
			var result = await _controller.GetAuthors();

			var okResult = result as OkObjectResult;
			Assert.NotNull(okResult);
			Assert.Equal(200, okResult.StatusCode);
			var listAuthors = okResult.Value as IEnumerable<AuthorDTO>;
			Assert.NotNull(listAuthors);
			Assert.Equal(2, listAuthors.Count());
			Assert.Equal(new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), listAuthors.First().Id);
			Assert.Equal("Jack", listAuthors.First().FirstName);
			Assert.Equal("London", listAuthors.First().LastName);
			Assert.Equal(new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), listAuthors.Last().Id);
			Assert.Equal("Jules", listAuthors.Last().FirstName);
			Assert.Equal("Verne", listAuthors.Last().LastName);
		}

		[Theory]
		[InlineData("3f9a0026-e78e-4307-a4df-c28470b7867d", "Jack", "London")]
		[InlineData("7c8075c1-26fa-4a8b-9292-d22515a16ad7", "Jules", "Verne")]
		public async Task Get_Author_By_Id_Should_Give_The_Right_Author(string id, string firstName, string lastName)
		{
			var result = await _controller.GetAuthor(new Guid(id));

			var okResult = result as OkObjectResult;
			Assert.NotNull(okResult);
			Assert.Equal(200, okResult.StatusCode);
			var author = okResult.Value as AuthorDTO;

			Assert.NotNull(author);
			Assert.Equal(new Guid(id), author.Id);
			Assert.Equal(firstName, author.FirstName);
			Assert.Equal(lastName, author.LastName);
			Assert.Equal(2, author.Books.Count);
		}

		[Fact]
		public async Task Get_Author_By_An_Non_Existant_Id_Should_Give_A_Not_Found()
		{
			var result = await _controller.GetAuthor(Guid.Empty);

			var notFoundResult = result as NotFoundResult;
			Assert.NotNull(notFoundResult);
			Assert.Equal(404, notFoundResult.StatusCode);
		}
	}
}