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
	//[CollectionDefinition("InMemoryDatabase")]
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

		~AuthorsControllerTests()
		{
			_fixture.Dispose();
		}

		[Fact]
		public async Task Get_Authors_Should_Give_Initial_Authors()
		{
			var result = await _controller.GetAuthors();

			var okResult = result as OkObjectResult;
			Assert.NotNull(okResult);
			Assert.Equal(200, okResult.StatusCode);
			var listAuthor = okResult.Value as IEnumerable<AuthorDTO>;
			Assert.NotNull(listAuthor);
			Assert.Equal(2, listAuthor.Count());
			Assert.Equal(new Guid("3f9a0026-e78e-4307-a4df-c28470b7867d"), listAuthor.First().Id);
			Assert.Equal("Jack", listAuthor.First().FirstName);
			Assert.Equal("London", listAuthor.First().LastName);
			Assert.Equal(new Guid("7c8075c1-26fa-4a8b-9292-d22515a16ad7"), listAuthor.Last().Id);
			Assert.Equal("Jules", listAuthor.Last().FirstName);
			Assert.Equal("Verne", listAuthor.Last().LastName);
		}
	}
}