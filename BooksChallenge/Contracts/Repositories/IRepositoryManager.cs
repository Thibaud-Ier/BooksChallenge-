using System.Threading.Tasks;

namespace Contracts.Repositories
{
	/// <summary>
	/// Interface for repository manager.
	/// </summary>
	public interface IRepositoryManager
	{
		/// <summary>
		/// The Author repository.
		/// </summary>
		IAuthorRepository Author { get; }

		/// <summary>
		/// The book repository.
		/// </summary>
		IBookRepository Book { get; }

		/// <summary>
		/// Save the changes in repositories.
		/// </summary>
		Task SaveAsync();
	}
}