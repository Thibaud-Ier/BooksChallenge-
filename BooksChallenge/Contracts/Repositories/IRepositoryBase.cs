using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts.Repositories
{
	/// <summary>
	/// Represents the base repository contract.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepositoryBase<T>
	{
		/// <summary>
		///	Find all elements.
		/// </summary>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		IQueryable<T> FindAll(bool trackChanges);

		/// <summary>
		/// Find all elements which matches the condition.
		/// </summary>
		/// <param name="expression"></param>
		/// <param name="trackChanges"></param>
		/// <returns></returns>
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

		/// <summary>
		/// Create element.
		/// </summary>
		/// <param name="entity"></param>
		void Create(T entity);

		/// <summary>
		/// Update element.
		/// </summary>
		/// <param name="entity"></param>
		void Update(T entity);

		/// <summary>
		/// Delete element.
		/// </summary>
		/// <param name="entity"></param>
		void Delete(T entity);
	}
}