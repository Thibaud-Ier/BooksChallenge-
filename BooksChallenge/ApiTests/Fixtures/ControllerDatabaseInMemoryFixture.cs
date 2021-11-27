using AutoMapper;
using BooksChallenge;
using Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiTests.Fixtures
{
	public sealed class ControllerWithDatabaseInMemoryFixture : IDisposable
	{
		private const string InMemoryConnectionString = "DataSource=:memory:";
		private readonly SqliteConnection _connection;

		public ControllerWithDatabaseInMemoryFixture()
		{
			var myProfile = new MappingProfile();
			var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

			Mapper = new Mapper(configuration);

			_connection = new SqliteConnection(InMemoryConnectionString);
			_connection.Open();

			var options = new DbContextOptionsBuilder<RepositoryContext>()
					.UseSqlite(_connection)
					.Options;

			Context = new RepositoryContext(options);
			Context.Database.EnsureCreated();
		}

		public RepositoryContext Context { get; private set; }

		public IMapper Mapper { get; private set; }

		public void Dispose()
		{
			_connection.Close();
			Context.Dispose();
		}
	}
}