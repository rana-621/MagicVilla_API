using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAllAsyc(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
		Task<T> GetAsyc(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null);
		Task CreateAsyc(T entity);
		Task RemoveAsyc(T entity);
		Task SaveAsyc();
	}
}
